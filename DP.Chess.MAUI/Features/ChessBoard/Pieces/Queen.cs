namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Queen : ChessPiece, IChessPiece
    {
        public Queen(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "Q")
        {
        }

        protected override Position[] UpdateMoveSet()
        {
            return new Position[0];
        }
    }
}