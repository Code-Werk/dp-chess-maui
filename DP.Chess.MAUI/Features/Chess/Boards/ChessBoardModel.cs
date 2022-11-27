using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure;
using System.Collections;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    public class ChessBoardModel : ObservableObject, IChessBoard

    {
        private readonly IChessCell[] _cells;

        private PlayerColor _currentPlayer;
        private bool _playerWon;
        private IChessCell? _selectedCell;
        private string _winnerText;

        public ChessBoardModel(IChessCell[] cells, PlayerColor currentPlayer)
        {
            _cells = cells;
            CurrentPlayer = currentPlayer;
            _winnerText = string.Empty;
        }

        /// <summary>
        /// Gets or sets the player that is currently making a move.
        /// </summary>
        public PlayerColor CurrentPlayer
        {
            get => _currentPlayer;
            set => SetProperty(ref _currentPlayer, value);
        }

        /// <summary>
        /// Gets or sets the flag to indicate that one of the two players won.
        /// </summary>
        public bool PlayerWon
        {
            get => _playerWon;
            set => SetProperty(ref _playerWon, value);
        }

        /// <summary>
        /// Gets or sets the cell that is currently selected.
        /// </summary>
        public IChessCell? SelectedCell
        {
            get => _selectedCell;
            set => SetProperty(ref _selectedCell, value);
        }

        /// <summary>
        /// Gets or sets the text displaying the winner of the current game.
        /// </summary>
        public string WinnerText
        {
            get => _winnerText;
            set => SetProperty(ref _winnerText, value);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IChessCell this[int x, int y] => _cells[y * 8 + x];

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IChessCell this[Position p] => _cells[p.ToChessBoardIndex()];

        public void EmptyCells()
        {
            foreach (IChessCell cell in this)
            {
                cell.Piece = null;
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerator<IChessCell> GetEnumerator() => _cells.Cast<IChessCell>().GetEnumerator();

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => _cells.GetEnumerator();

        #region Memento

        public void RestoreMemento(ChessMemento memento)
        {
            PlayerWon = memento.PlayerWon;
            WinnerText = memento.WinnerText;
            CurrentPlayer = memento.CurrentPlayer;
            EmptyCells();

            foreach (IChessPiece cp in GetSavedPieces(memento))
            {
                _cells[cp.CurrentPosition.ToChessBoardIndex()].Piece = cp;
            }
        }

        public ChessMemento SaveMemento()
        {
            return new(
                currentPlayer: CurrentPlayer,
                pieces: GetSerializedChessPieces(),
                playerWon: PlayerWon,
                winnerText: WinnerText); ;
        }

        private static IChessPiece GetChessPiece(ChessPieceMemento cp)
        {
            return cp.Symbol switch
            {
                "B" => new Bishop(cp.Color, cp.Position),
                "KI" => new King(cp.Color, cp.Position),
                "KN" => new Knight(cp.Color, cp.Position),
                "P" => new Pawn(cp.Color, cp.Position),
                "Q" => new Queen(cp.Color, cp.Position),
                "R" => new Rook(cp.Color, cp.Position),
                _ => throw new ArgumentException("the loaded piece contained an unknown symbol"),
            };
        }

        private static IList<IChessPiece> GetSavedPieces(ChessMemento deserializedSave)
        {
            IList<IChessPiece> pieces = new List<IChessPiece>();

            foreach (ChessPieceMemento cp in deserializedSave.Pieces)
            {
                pieces.Add(GetChessPiece(cp));
            }

            return pieces;
        }

        private IList<ChessPieceMemento> GetSerializedChessPieces()
        {
            IList<ChessPieceMemento> pieces = new List<ChessPieceMemento>();

            foreach (IChessCell c in _cells)
            {
                if (c.Piece is IChessPiece piece)
                {
                    pieces.Add(new ChessPieceMemento(
                        color: piece.Color,
                        position: piece.CurrentPosition,
                        symbol: piece.Symbol
                    ));
                }
            }

            return pieces;
        }

        #endregion Memento
    }
}