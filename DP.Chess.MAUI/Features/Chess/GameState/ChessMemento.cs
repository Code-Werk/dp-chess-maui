using DP.Chess.MAUI.Infrastructure.Memento;

namespace DP.Chess.MAUI.Features.Chess.GameState
{
    /// <summary>
    /// Class containing a chess game representation that can be deserialized to
    /// JSON and written to a save file.
    /// </summary>
    public class ChessMemento : IMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessMemento" /> class.
        /// Default constructor for serialization.
        /// </summary>
        public ChessMemento(PlayerColor currentPlayer, IList<ChessPieceMemento> pieces, bool playerWon, string winnerText)
        {
            CurrentPlayer = currentPlayer;
            Pieces = pieces;
            PlayerWon = playerWon;
            WinnerText = winnerText;
        }

        public PlayerColor CurrentPlayer { get; set; }

        public IList<ChessPieceMemento> Pieces { get; set; }

        public bool PlayerWon { get; set; }

        public string WinnerText { get; set; }
    }
}