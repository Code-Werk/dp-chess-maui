namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Bishop : ChessPiece, IChessPiece
    {
        public Bishop(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "B")
        {
        }

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            throw new NotImplementedException();
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // TODO: clean-up code

            // to top left
            int moveableX = CurrentPosition.X;
            int moveableY = CurrentPosition.Y;
            while (moveableX > 0 || moveableY > 0)
            {
                moveableX--;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            // to top right
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX > 0 || moveableY < 7)
            {
                moveableX--;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            // to bottom left
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX < 7 || moveableY > 0)
            {
                moveableX++;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            // to bottom right
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX < 7 || moveableY < 7)
            {
                moveableX++;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableX));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}