namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Knight : ChessPiece, IChessPiece
    {
        public Knight(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "KN")
        {
        }

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            IChessPiece pieceAtTarget = board[targetCell.Position.ToBoardIndex()].ChessPiece;

            // the knight can jump over other pieces in its way,
            // thus we do not need to check for that
            return pieceAtTarget == null || Color != pieceAtTarget.Color;
        }

        public override void UpdatePossibleMoveSet()
        {
            // add any possible 2 in x and 1 in y, add any possible 2 in y and 1 in x

            PossibleMoveSet = new Position[0];
        }
    }
}