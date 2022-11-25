namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Interface for services that contain movement logic specific for chess pieces.
    /// </summary>
    public interface IChessBoardMovementService : IMovementService<IChessBoard, IChessCell, IChessPiece>
    {
    }
}