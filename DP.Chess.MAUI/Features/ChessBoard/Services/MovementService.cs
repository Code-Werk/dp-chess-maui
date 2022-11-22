using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard
{
    public class MovementService : IMovementService
    {
        public bool CanMove(CellModel[] board, IChessPiece piece, CellModel targetCell)
        {
            piece.UpdatePossibleMoveSet();

            if (!piece.PossibleMoveSet.Contains(targetCell.Position))
            {
                return false;
            }

            return piece.CheckTargetPosition(board, targetCell);
        }

        public void Move(IChessPiece piece, CellModel sourceCell, CellModel targetCell)
        {
            piece.CurrentPosition = targetCell.Position;
            sourceCell.ChessPiece = null;
            targetCell.ChessPiece = piece;

            // TODO: do we need to check if an opponent figure was taken?
        }
    }
}