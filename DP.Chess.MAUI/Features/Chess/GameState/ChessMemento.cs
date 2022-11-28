using DP.Chess.MAUI.Infrastructure.Memento;

namespace DP.Chess.MAUI.Features.Chess.GameState
{
    /// <summary>
    /// Class containing a chess board representation that is used to save
    /// its state as part of the chess board memento.
    /// The class can be deserialized to JSON and written to a
    /// save file to persist the state of the piece.
    /// </summary>
    public class ChessMemento : IMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessMemento" /> class.
        /// </summary>
        /// <param name="currentPlayer">The player that can currently make their move.</param>
        /// <param name="pieces">The list of chess pieces currently on the chess board.</param>
        /// <param name="playerWon">The flag to indicate that one of the two players won.</param>
        /// <param name="winnerText">The text displaying the winner of the current game.</param>
        public ChessMemento(PlayerColor currentPlayer, IList<ChessPieceMemento> pieces, bool playerWon, string winnerText)
        {
            CurrentPlayer = currentPlayer;
            Pieces = pieces;
            PlayerWon = playerWon;
            WinnerText = winnerText;
        }

        /// <summary>
        /// Gets or sets the player that can currently make their move.
        /// </summary>
        public PlayerColor CurrentPlayer { get; set; }

        /// <summary>
        /// Gets or sets the list of chess pieces currently on the chess board.
        /// </summary>
        public IList<ChessPieceMemento> Pieces { get; set; }

        /// <summary>
        /// Gets or sets the flag to indicate that one of the two players won.
        /// </summary>
        public bool PlayerWon { get; set; }

        /// <summary>
        /// Gets or sets the text displaying the winner of the current game.
        /// </summary>
        public string WinnerText { get; set; }
    }
}