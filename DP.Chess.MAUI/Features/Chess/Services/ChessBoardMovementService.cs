using DP.Chess.MAUI.Features.Chess.Pieces;

namespace DP.Chess.MAUI.Features.Chess
{
    public class ChessBoardMovementService : IChessBoardMovementService
    {
        public bool CanMove(IChessBoard board, IChessPiece piece, IChessCell target)
        {
            piece.UpdatePossibleMoveSet();

            if (!piece.PossibleMoveSet.Contains(target.Position))
            {
                return false;
            }

            return piece.CheckTargetPosition(board, target);
        }

        public void Move(IChessPiece piece, IChessCell source, IChessCell target)
        {
            piece.CurrentPosition = target.Position;
            source.Piece = null;
            target.Piece = piece;

            // TODO: do we need to check if an opponent figure was taken?
        }
    }
}