namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Bishop : ChessPiece, IChessPiece
    {
        public Bishop(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "B")
        {
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

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