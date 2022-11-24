using CommunityToolkit.Mvvm.Input;
using DP.Chess.MAUI.Features.Chess.Pieces;
using System.Collections;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features.Chess
{
    public class ChessBoard : IEnumerable<IChessCell>, IChessBoard
    {
        private readonly IChessCell[] _cells;
        private readonly IChessBoardMovementService _movementService;

        private IChessPiece _selectedPiece;

        public ChessBoard(IChessBoardMovementService movementService)
        {
            _movementService = movementService;

            _cells = new ChessCellModel[8 * 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Position position = new(x, y);
                    _cells[ToBoardIndex(position)] = new ChessCellModel(position);
                }
            }

            // TODO: ChessBoardFactory
            InitBoard();
        }

        public IChessCell this[int x, int y] => _cells[y * 8 + x];

        public IChessCell this[Position p] => _cells[ChessBoard.ToBoardIndex(p)];

        public IEnumerator<IChessCell> GetEnumerator() => _cells.Cast<IChessCell>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _cells.GetEnumerator();

        public void InitBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                _cells[8 + x].Piece = new Pawn(ColorSet.Black, _cells[8 + x].Position);
                _cells[6 * 8 + x].Piece = new Pawn(ColorSet.White, _cells[6 * 8 + x].Position);
            }

            _cells[0].Piece = new Rook(ColorSet.Black, _cells[0].Position);
            _cells[7].Piece = new Rook(ColorSet.Black, _cells[7].Position);

            _cells[7 * 8].Piece = new Rook(ColorSet.White, _cells[7 * 8].Position);
            _cells[7 * 8 + 7].Piece = new Rook(ColorSet.White, _cells[7 * 8 + 7].Position);

            _cells[1].Piece = new Knight(ColorSet.Black, _cells[1].Position);
            _cells[6].Piece = new Knight(ColorSet.Black, _cells[6].Position);

            _cells[7 * 8 + 1].Piece = new Knight(ColorSet.White, _cells[7 * 8 + 1].Position);
            _cells[7 * 8 + 6].Piece = new Knight(ColorSet.White, _cells[7 * 8 + 6].Position);

            _cells[2].Piece = new Bishop(ColorSet.Black, _cells[2].Position);
            _cells[5].Piece = new Bishop(ColorSet.Black, _cells[5].Position);

            _cells[7 * 8 + 2].Piece = new Bishop(ColorSet.White, _cells[7 * 8 + 2].Position);
            _cells[7 * 8 + 5].Piece = new Bishop(ColorSet.White, _cells[7 * 8 + 5].Position);

            _cells[3].Piece = new King(ColorSet.Black, _cells[3].Position);
            _cells[7 * 8 + 3].Piece = new King(ColorSet.White, _cells[7 * 8 + 3].Position);

            _cells[4].Piece = new Queen(ColorSet.Black, _cells[4].Position);
            _cells[7 * 8 + 4].Piece = new Queen(ColorSet.White, _cells[7 * 8 + 4].Position);
        }

        private static int ToBoardIndex(Position position)
        {
            return position.Y * 8 + position.X;
        }

        private void RemoveCellSelection()
        {
            foreach (IChessCell cell in this)
            {
                cell.IsSelected = false;
            }
        }

        #region ChessMoveCommand

        private ICommand _chessMoveCommand;

        /// <summary>
        /// Gets the command that is executed to make a chess move (Schachzug)
        /// in the game. A complete chess turn executes this command twice, once
        /// to select the piece that should be moved, and a second time to move
        /// the piece to the desired position. The move may contain taking an
        /// opponent piece or not.
        /// </summary>
        public ICommand ChessMoveCommand => _chessMoveCommand
            ??= new RelayCommand<IChessCell>(DoChessMove);

        private void DoChessMove(IChessCell cell)
        {
            if (_selectedPiece == null && cell.Piece == null)
            {
                RemoveCellSelection();
                return;
            }

            // chess piece to move was selected for the first time this move
            if (_selectedPiece == null)
            {
                _selectedPiece = cell.Piece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            // player clicked on another piece of the same color
            if (_selectedPiece.Color == cell.Piece?.Color)
            {
                _selectedPiece = cell.Piece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            try
            {
                if (!_movementService.CanMove(this, _selectedPiece, cell))
                {
                    // TODO: notification (not a valid position yada yada)
                    return;
                }

                // an empty field or one occupied by an opponent was selected
                _movementService.Move(_selectedPiece, this[_selectedPiece.CurrentPosition], cell);
            }
            finally
            {
                // reset the selected piece for the next move
                RemoveCellSelection();
                _selectedPiece = null;
            }
        }

        #endregion ChessMoveCommand
    }
}