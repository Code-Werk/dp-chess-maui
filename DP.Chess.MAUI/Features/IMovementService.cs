namespace DP.Chess.MAUI.Features
{
    public interface IMovementService<TBoard, TCell, TPiece>
        where TBoard : IBoard<TCell, TPiece>
        where TCell : ICell<TPiece>
        where TPiece : IPiece
    {
        bool CanMove(TBoard board, TPiece piece, TCell targetCell);

        void Move(TPiece piece, TCell sourceCell, TCell targetCell);
    }
}