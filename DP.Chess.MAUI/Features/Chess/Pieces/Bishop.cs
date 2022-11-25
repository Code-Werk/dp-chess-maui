using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the bishop chess piece.
    /// </summary>
    public class Bishop : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Bishop"/> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">The position of a piece on the board it has at creation.</param>
        public Bishop(PlayerColor color, Position currentPosition)
            : base(color, currentPosition, "B")
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            bool canMove = true;
            Position targetPosition = targetCell.Position;
            IChessPiece pieceAtTarget = board[targetPosition].Piece;

            canMove &= pieceAtTarget == null || Color != pieceAtTarget.Color;
            canMove &= PieceMovementTools.CheckDiagonalMovement(this, board, targetPosition);

            return canMove;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            PossibleMoveSet = PieceMovementTools.BuildDiagonalMoveSet(this);
        }
    }
}