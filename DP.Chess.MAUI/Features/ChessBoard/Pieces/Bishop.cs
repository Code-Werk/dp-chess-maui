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
            bool canMove = true;
            int currentBoardIndex = CurrentPosition.ToBoardIndex();
            Position targetPosition = targetCell.Position;
            int targetBoardIndex = targetPosition.ToBoardIndex();

            IChessPiece pieceAtTarget = board[targetBoardIndex].ChessPiece;
            canMove &= pieceAtTarget == null || Color != pieceAtTarget.Color;

            // TODO: cleanup if there's a better way
            // TODO: taking opponent not yet considered

            // move left
            if (targetPosition.X < CurrentPosition.X)
            {
                // move up
                if (targetPosition.Y < CurrentPosition.Y)
                {
                    for (int i = currentBoardIndex - 9; i >= targetBoardIndex; i -= 9) // y: -8, x: -1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = currentBoardIndex + 7; i <= targetBoardIndex; i += 7) // y: +8, x: -1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
            }
            // move right
            else
            {
                // move up
                if (targetPosition.Y < CurrentPosition.Y)
                {
                    for (int i = currentBoardIndex - 7; i >= targetBoardIndex; i -= 7) // y: -8, x: +1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = currentBoardIndex + 9; i <= targetBoardIndex; i += 9) // y: +8, x: +1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
            }

            return canMove;
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // TODO: clean-up code

            // to top left
            int moveableX = CurrentPosition.X;
            int moveableY = CurrentPosition.Y;
            while (moveableX > 0 && moveableY > 0)
            {
                moveableX--;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to top right
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX < 7 && moveableY > 0)
            {
                moveableX++;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to bottom left
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX > 0 && moveableY < 7)
            {
                moveableX--;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to bottom right
            moveableX = CurrentPosition.X;
            moveableY = CurrentPosition.Y;
            while (moveableX < 7 && moveableY < 7)
            {
                moveableX++;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}