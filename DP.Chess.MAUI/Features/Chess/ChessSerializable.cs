using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess
{
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