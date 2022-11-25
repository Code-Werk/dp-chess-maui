﻿namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the rook chess piece.
    /// </summary>
    public class Rook : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rook"/> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">The position of a piece on the board it has at creation.</param>
        public Rook(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "R")
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

            canMove &= pieceAtTarget == null || Color != pieceAtTarget?.Color;
            canMove &= PieceMovementTools.CheckStraightMovement(this, board, targetPosition);

            return canMove;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            PossibleMoveSet = PieceMovementTools.BuildStraightMoveSet(this);
        }
    }
}