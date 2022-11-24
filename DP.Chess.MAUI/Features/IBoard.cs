namespace DP.Chess.MAUI.Features
{
    public interface IBoard<TCell, TPiece> : IEnumerable<TCell>
        where TCell : ICell<TPiece>
        where TPiece : IPiece
    {
        TCell this[int x, int y] { get; }

        TCell this[Position p] { get; }
    }
}