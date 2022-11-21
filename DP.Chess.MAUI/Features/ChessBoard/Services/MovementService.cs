using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard.Services
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

            // TODO check if path is blocked

            throw new NotImplementedException();
        }

        public void Move(IChessPiece piece, Position destination)
        {
            piece.CurrentPosition = destination;

            // TODO: do we need to check if an opponent figure was taken?
        }
    }
}