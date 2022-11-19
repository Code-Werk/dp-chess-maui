namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Rook : ChessPiece, IChessPiece
    {
        public Rook(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "R")
        {
        }

        protected override Position[] UpdateMoveSet()
        {
            return new Position[0];
        }
    }
}