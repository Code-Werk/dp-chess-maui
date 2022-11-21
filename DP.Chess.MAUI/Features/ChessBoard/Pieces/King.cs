namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class King : ChessPiece, IChessPiece
    {
        public King(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "KI")
        {
        }

        public override void UpdatePossibleMoveSet()
        {
            List<Position> moveSet = new();

            int minX = CurrentPosition.X <= 0 ? 0 : CurrentPosition.X - 1;
            int maxX = CurrentPosition.X >= 8 ? 8 : CurrentPosition.X + 1;

            int minY = CurrentPosition.Y <= 0 ? 0 : CurrentPosition.Y - 1;
            int maxY = CurrentPosition.Y >= 8 ? 8 : CurrentPosition.Y + 1;

            for (int x = minX; x <= maxX; x++)
                for (int y = minY; y <= maxY; y++)
                {
                    Position newPosition = new(x, y);
                    if (newPosition != CurrentPosition)
                    {
                        moveSet.Add(newPosition);
                    }
                }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}