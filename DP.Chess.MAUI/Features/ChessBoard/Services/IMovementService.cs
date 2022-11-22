using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard
{
    public interface IMovementService
    {
        bool CanMove(CellModel[] board, IChessPiece piece, CellModel targetCell);

        void Move(IChessPiece piece, CellModel sourceCell, CellModel targetCell);
    }
}