using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Class containing a chess piece representation that can be deserialized
    /// to JSON and written to a save file.
    /// </summary>
    public class ChessPieceSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceSerializable"/> class.
        /// Default constructor for serialization.
        /// </summary>
        public ChessPieceSerializable()
        {
        }

        public PlayerColor Color { get; set; }

        public Position Position { get; set; }

        public string Symbol { get; set; }
    }

    /// <summary>
    /// Class containing a chess game representation that can be deserialized
    /// to JSON and written to a save file.
    /// </summary>
    public class ChessSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessSerializable"/> class.
        /// Default constructor for serialization.
        /// </summary>
        public ChessSerializable()
        {
        }

        public PlayerColor CurrentPlayer { get; set; }

        public IList<ChessPieceSerializable> Pieces { get; set; }
    }
}