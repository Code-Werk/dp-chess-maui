using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard.Services
{
    public interface IMovementService
    {
        bool CanMove(CellModel[] board, IChessPiece piece, CellModel targetCell);

        void Move(IChessPiece piece, Position destination);
    }
}