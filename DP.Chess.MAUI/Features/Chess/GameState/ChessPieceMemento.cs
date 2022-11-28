using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.GameState
{
    /// <summary>
    /// Class containing a chess piece representation that is used to save
    /// its state as part of the chess board memento.
    /// The class can be deserialized to JSON and written to a
    /// save file to persist the state of the piece.
    /// </summary>
    public class ChessPieceMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceMemento" />
        /// class.
        /// </summary>
        /// <param name="color">The color of the chess piece.</param>
        /// <param name="position">The current position of the chess piece on the board.</param>
        /// <param name="symbol">The symbol of the chess piece that represents it on the board.</param>
        public ChessPieceMemento(PlayerColor color, Position position, string symbol)
        {
            Color = color;
            Position = position;
            Symbol = symbol;
        }

        /// <summary>
        /// Gets or sets the color of the chess piece.
        /// </summary>
        public PlayerColor Color { get; set; }

        /// <summary>
        /// Gets or sets the current position of the chess piece on the board.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the symbol of the chess piece that represents it on the board.
        /// </summary>
        public string Symbol { get; set; }
    }
}