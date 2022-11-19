namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Pawn : ChessPiece, IChessPiece
    {
        public Pawn(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "P")
        {
        }

        protected override Position[] UpdateMoveSet()
        {
            if (CurrentPosition.Y >= 7)
            {
                return Array.Empty<Position>();
            }

            return new[]
            {
                new Position(CurrentPosition.X, CurrentPosition.Y + 1)
            };
        }
    }
}