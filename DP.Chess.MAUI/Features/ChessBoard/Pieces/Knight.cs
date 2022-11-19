namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Knight : ChessPiece, IChessPiece
    {
        public Knight(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "KN")
        {
        }

        protected override Position[] UpdateMoveSet()
        {
            return new Position[0];
        }
    }
}