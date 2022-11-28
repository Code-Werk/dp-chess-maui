using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the queen chess piece.
    /// </summary>
    public class Queen : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Queen" /> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">
        /// The position of a piece on the board that it has after creation.
        /// </param>
        public Queen(PlayerColor color, Position currentPosition)
            : base(color, currentPosition, "Q")
        {
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <param name="targetCell"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            bool canMove = true;
            Position targetPosition = targetCell.Position;
            IChessPiece? pieceAtTarget = board[targetPosition].Piece;

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

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            List<Position> moveSet = new();

            moveSet.AddRange(PieceMovementTools.BuildStraightMoveSet(this));
            moveSet.AddRange(PieceMovementTools.BuildDiagonalMoveSet(this));

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}