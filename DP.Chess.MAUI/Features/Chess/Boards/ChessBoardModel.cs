using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure;
using System.Collections;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// Class representing a chess board. It implements the
    /// <see cref="ObservableObject" /> class to notify any observers of its
    /// instances (e.g. the UI).
    /// </summary>
    public class ChessBoardModel : ObservableObject, IChessBoard

    {
        private readonly IChessCell[] _cells;

        private PlayerColor _currentPlayer;
        private bool _playerWon;
        private IChessCell? _selectedCell;
        private string _winnerText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoardModel"/> class.
        /// </summary>
        /// <param name="cells">The list of cells for the chess board.</param>
        /// <param name="currentPlayer">The player that can currently make their move.</param>
        public ChessBoardModel(IChessCell[] cells, PlayerColor currentPlayer)
        {
            _cells = cells;
            CurrentPlayer = currentPlayer;
            _winnerText = string.Empty;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public PlayerColor CurrentPlayer
        {
            get => _currentPlayer;
            set => SetProperty(ref _currentPlayer, value);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool PlayerWon
        {
            get => _playerWon;
            set => SetProperty(ref _playerWon, value);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IChessCell? SelectedCell
        {
            get => _selectedCell;
            set => SetProperty(ref _selectedCell, value);
        }

        /// <summary>
        /// <inheritdoc />
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

        /// <summary>
        /// Method that recreates the state of the chess board from a <see cref="ChessMemento"/>.
        /// </summary>
        /// <param name="memento">The memento that should be recreated as the current game state.</param>
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

        /// <summary>
        /// Method that saves the current state of the chess board as <see cref="ChessMemento"/>.
        /// </summary>
        /// <returns>The created <see cref="ChessMemento"/>.</returns>
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