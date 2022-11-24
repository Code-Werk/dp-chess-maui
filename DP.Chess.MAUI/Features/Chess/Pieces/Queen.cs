namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    public class Queen : ChessPiece, IChessPiece
    {
        public Queen(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "Q")
        {
        }

        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            bool canMove = true;
            Position targetPosition = targetCell.Position;
            IChessPiece pieceAtTarget = board[targetPosition].Piece;

            canMove &= pieceAtTarget == null || Color != pieceAtTarget.Color;
            if (CurrentPosition.X == targetPosition.X || CurrentPosition.Y == targetPosition.Y)
            {
                canMove &= PieceMovementTools.CheckStraightMovement(this, board, targetPosition);
            }
            else
            {
                canMove &= PieceMovementTools.CheckDiagonalMovement(this, board, targetPosition);
            }

            return canMove;
        }

        public override void UpdatePossibleMoveSet()
        {
            List<Position> moveSet = new();

            moveSet.AddRange(PieceMovementTools.BuildStraightMoveSet(this));
            moveSet.AddRange(PieceMovementTools.BuildDiagonalMoveSet(this));

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}