namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Knight : ChessPiece, IChessPiece
    {
        public Knight(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "KN")
        {
        }

        public override void UpdatePossibleMoveSet()
        {
            PossibleMoveSet = new Position[0];
        }
    }
}