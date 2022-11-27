using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.GameState
{
    /// <summary>
    /// Class containing a chess piece representation that can be deserialized
    /// to JSON and written to a save file.
    /// </summary>
    public class ChessPieceMemento
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceMemento" />
        /// class. Default constructor for serialization.
        /// </summary>
        public ChessPieceMemento(PlayerColor color, Position position, string symbol)
        {
            Color = color;
            Position = position;
            Symbol = symbol;
        }

        public PlayerColor Color { get; set; }

        public Position Position { get; set; }

        public string Symbol { get; set; }
    }
}