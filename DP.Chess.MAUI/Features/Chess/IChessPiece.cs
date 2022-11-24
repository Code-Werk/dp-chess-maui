namespace DP.Chess.MAUI.Features.Chess
{
    public interface IChessPiece : IPiece
    {
        ColorSet Color { get; }

        bool CheckTargetPosition(IChessBoard board, IChessCell target);

        void UpdatePossibleMoveSet();
    }
}