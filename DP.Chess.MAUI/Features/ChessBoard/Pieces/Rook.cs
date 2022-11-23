﻿namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Rook : ChessPiece, IChessPiece
    {
        public Rook(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "R")
        {
        }

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            bool canMove = true;
            Position targetPosition = targetCell.Position;
            IChessPiece pieceAtTarget = board[targetPosition.ToBoardIndex()].ChessPiece;

            canMove &= pieceAtTarget == null || Color != pieceAtTarget?.Color;
            canMove &= PieceMovementTools.CheckStraightMovement(this, board, targetPosition);

            return canMove;
        }

        public override void UpdatePossibleMoveSet()
        {
            PossibleMoveSet = PieceMovementTools.BuildStraightMoveSet(this);
        }
    }
}