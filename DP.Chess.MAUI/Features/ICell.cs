namespace DP.Chess.MAUI.Features
{
    public interface ICell<T> where T : IPiece
    {
        bool IsSelected { get; set; }

        public T Piece { get; set; }

        public Position Position { get; }
    }
}