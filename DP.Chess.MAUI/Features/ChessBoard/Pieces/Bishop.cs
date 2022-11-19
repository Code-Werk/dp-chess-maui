namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Bishop : ChessPiece, IChessPiece
    {
        public Bishop(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "B")
        {
        }

        protected override Position[] UpdateMoveSet()
        {
            return new Position[0];
        }
    }
}