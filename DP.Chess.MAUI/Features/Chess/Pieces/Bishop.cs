namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    public class Bishop : ChessPiece, IChessPiece
    {
        public Bishop(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "B")
        {
        }

        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            bool canMove = true;
            Position targetPosition = targetCell.Position;
            IChessPiece pieceAtTarget = board[targetPosition].Piece;

            canMove &= pieceAtTarget == null || Color != pieceAtTarget.Color;
            canMove &= PieceMovementTools.CheckStraightMovement(this, board, targetPosition);

            return canMove;
        }

        public override void UpdatePossibleMoveSet()
        {
            PossibleMoveSet = PieceMovementTools.BuildDiagonalMoveSet(this);
        }
    }
}