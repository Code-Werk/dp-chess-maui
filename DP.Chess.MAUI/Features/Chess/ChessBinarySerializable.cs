using System.Runtime.Serialization;

namespace DP.Chess.MAUI.Features.Chess
{
    [Serializable]
    public class ChessBinarySerializable : ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBinarySerializable"/> class.
        /// Default constructor for serialization.
        /// </summary>
        public ChessBinarySerializable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBinarySerializable"/> class.
        /// Constructor for deserialization.
        /// </summary>
        public ChessBinarySerializable(SerializationInfo info, StreamingContext context)
        {
            Pieces = (IList<ChessPieceSerializable>)info.GetValue(nameof(Pieces), typeof(IList<ChessPieceSerializable>));
            CurrentPlayer = (string)info.GetValue(nameof(CurrentPlayer), typeof(string));
        }

        public string CurrentPlayer { get; set; }

        public IList<ChessPieceSerializable> Pieces { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Pieces = (IList<ChessPieceSerializable>)info.GetValue(nameof(Pieces), typeof(IList<ChessPieceSerializable>));
            CurrentPlayer = (string)info.GetValue(nameof(CurrentPlayer), typeof(string));
        }
    }

    [Serializable]
    public class ChessPieceBinarySerializable : ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceBinarySerializable"/> class.
        /// Default constructor for serialization.
        /// </summary>
        public ChessPieceBinarySerializable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPieceBinarySerializable"/> class.
        /// Constructor for deserialization.
        /// </summary>
        public ChessPieceBinarySerializable(SerializationInfo info, StreamingContext context)
        {
            Color = (int)info.GetValue(nameof(Color), typeof(int));
            PositionX = (int)info.GetValue(nameof(PositionX), typeof(int));
            PositionY = (int)info.GetValue(nameof(PositionY), typeof(int));
            Symbol = (string)info.GetValue(nameof(Symbol), typeof(string));
        }

        public int Color { get; set; }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public string Symbol { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Color = (int)info.GetValue(nameof(Color), typeof(int));
            PositionX = (int)info.GetValue(nameof(PositionX), typeof(int));
            PositionY = (int)info.GetValue(nameof(PositionY), typeof(int));
            Symbol = (string)info.GetValue(nameof(Symbol), typeof(string));
        }
    }
}