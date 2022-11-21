namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Queen : ChessPiece, IChessPiece
    {
        public Queen(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "Q")
        {
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                Position px = new(CurrentPosition.X, i);
                Position py = new(i, CurrentPosition.Y);

                if (px != CurrentPosition)
                {
                    moveSet.Add(px);
                }
                if (py != CurrentPosition)
                {
                    moveSet.Add(py);
                }
            }

            int moveableX = CurrentPosition.X;
            int moveableY = CurrentPosition.Y;
            while (moveableX > 0 || moveableY > 0)
            {
                moveableX--;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX < 7 || moveableY > 7)
            {
                moveableX++;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}