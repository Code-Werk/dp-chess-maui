using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DP.Chess.MAUI.Features.Chess.Pieces;
using System.Collections;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Class representing a chess board.
    /// It implements the <see cref="ObservableObject"/> class to notify
    /// any observers of its instances (e.g. the UI).
    /// </summary>
    public class ChessBoard : ObservableObject, IEnumerable<IChessCell>, IChessBoard
    {
        private readonly IChessCell[] _cells;
        private readonly IChessBoardMovementService _movementService;

        private ColorSet _currentPlayer;
        private IChessPiece _selectedPiece;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoard"/> class.
        /// </summary>
        /// <param name="movementService">The service containing chess piece movement logic.</param>
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
            CurrentPlayer = ColorSet.White;

            // TODO: ChessBoardFactory
            InitBoard();
        }

        public ColorSet CurrentPlayer
        {
            get => _currentPlayer;
            set => SetProperty(ref _currentPlayer, value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IChessCell this[int x, int y] => _cells[y * 8 + x];

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IChessCell this[Position p] => _cells[ChessBoard.ToBoardIndex(p)];

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerator<IChessCell> GetEnumerator() => _cells.Cast<IChessCell>().GetEnumerator();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => _cells.GetEnumerator();

        /// <summary>
        /// Method that initializes the chess board for a new game.
        /// </summary>
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
            if (_selectedPiece == null
                && (cell.Piece == null || cell.Piece.Color != CurrentPlayer))
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
                    IToast toast = Toast.Make("Invalid move.", ToastDuration.Short);
                    toast.Show();
                    return;
                }

                // an empty field or one occupied by an opponent was selected
                _movementService.Move(_selectedPiece, this[_selectedPiece.CurrentPosition], cell);
                CurrentPlayer = CurrentPlayer == ColorSet.White
                    ? ColorSet.Black
                    : ColorSet.White;
            }
            finally
            {
                // reset the selected piece for the next move
                RemoveCellSelection();
                _selectedPiece = null;
            }
        }

        #endregion ChessMoveCommand

        #region LoadCommand

        private ICommand _loadCommand;

        /// <summary>
        /// Gets the command that is executed to load a previously saved game.
        /// It allows the user to pick a save file, which will then be loaded and
        /// the board will be initialized accordingly.
        /// </summary>
        public ICommand LoadCommand => _loadCommand
            ??= new AsyncRelayCommand(LoadGame);

        private async Task LoadGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion LoadCommand

        #region UndoCommand

        private ICommand _undoCommand;

        /// <summary>
        /// Command that is executed to undo a previously made chess move.
        /// It loads the state of the board from the previous move.
        /// </summary>
        public ICommand UndoCommand => _undoCommand
            ??= new RelayCommand(UndoMove);

        private void UndoMove()
        {
            throw new NotImplementedException();
        }

        #endregion UndoCommand

        #region RedoCommand

        private ICommand _redoCommand;

        /// <summary>
        /// Command that is executed to redo a previously undone chess move.
        /// It loads the state of the board from the undone move.
        /// </summary>
        public ICommand RedoCommand => _redoCommand
            ??= new RelayCommand(RedoMove);

        private void RedoMove()
        {
            throw new NotImplementedException();
        }

        #endregion RedoCommand

        #region SaveCommand

        private ICommand _saveCommand;

        /// <summary>
        /// Command that is executed to save the current state of the board
        /// into a save file.
        /// </summary>
        public ICommand SaveCommand => _saveCommand
            ??= new AsyncRelayCommand(SaveGame);

        private async Task SaveGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion SaveCommand
    }
}