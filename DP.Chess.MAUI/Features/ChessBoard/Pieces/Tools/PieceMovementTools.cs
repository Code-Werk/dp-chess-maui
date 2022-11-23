namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public static class PieceMovementTools
    {
        public static Position[] BuildDiagonalMoveSet(IChessPiece piece)
        {
            IList<Position> moveSet = new List<Position>();

            // to top left
            int moveableX = piece.CurrentPosition.X;
            int moveableY = piece.CurrentPosition.Y;
            while (moveableX > 0 && moveableY > 0)
            {
                moveableX--;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to top right
            moveableX = piece.CurrentPosition.X;
            moveableY = piece.CurrentPosition.Y;
            while (moveableX < 7 && moveableY > 0)
            {
                moveableX++;
                moveableY--;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to bottom left
            moveableX = piece.CurrentPosition.X;
            moveableY = piece.CurrentPosition.Y;
            while (moveableX > 0 && moveableY < 7)
            {
                moveableX--;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            // to bottom right
            moveableX = piece.CurrentPosition.X;
            moveableY = piece.CurrentPosition.Y;
            while (moveableX < 7 && moveableY < 7)
            {
                moveableX++;
                moveableY++;
                moveSet.Add(new Position(moveableX, moveableY));
            }

            return moveSet.ToArray();
        }

        public static Position[] BuildStraightMoveSet(IChessPiece piece)
        {
            IList<Position> moveSet = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                Position px = new(piece.CurrentPosition.X, i);
                Position py = new(i, piece.CurrentPosition.Y);

                if (px != piece.CurrentPosition)
                {
                    moveSet.Add(px);
                }
                if (py != piece.CurrentPosition)
                {
                    moveSet.Add(py);
                }
            }

            return moveSet.ToArray();
        }

        public static bool CheckDiagonalMovement(IChessPiece piece, CellModel[] board, Position targetPosition)
        {
            bool canMove = true;
            int currentBoardIndex = piece.CurrentPosition.ToBoardIndex();
            int targetBoardIndex = targetPosition.ToBoardIndex();

            // move left
            if (targetPosition.X < piece.CurrentPosition.X)
            {
                // move up
                if (targetPosition.Y < piece.CurrentPosition.Y)
                {
                    for (int i = currentBoardIndex - 9; i > targetBoardIndex; i -= 9) // y: -8, x: -1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = currentBoardIndex + 7; i < targetBoardIndex; i += 7) // y: +8, x: -1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
            }
            // move right
            else
            {
                // move up
                if (targetPosition.Y < piece.CurrentPosition.Y)
                {
                    for (int i = currentBoardIndex - 7; i > targetBoardIndex; i -= 7) // y: -8, x: +1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = currentBoardIndex + 9; i < targetBoardIndex; i += 9) // y: +8, x: +1
                    {
                        canMove &= board[i].ChessPiece == null;
                    }
                }
            }

            return canMove;
        }

        public static bool CheckStraightMovement(IChessPiece piece, CellModel[] board, Position targetPosition)
        {
            bool canMove = true;
            int currentBoardIndex = piece.CurrentPosition.ToBoardIndex();
            int targetBoardIndex = targetPosition.ToBoardIndex();

            // move left
            if (targetPosition.X < piece.CurrentPosition.X)
            {
                for (int i = currentBoardIndex - 1; i > targetBoardIndex; i--)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move right
            else if (targetPosition.X > piece.CurrentPosition.X)
            {
                for (int i = currentBoardIndex + 1; i < targetBoardIndex; i++)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move up
            else if (targetPosition.Y < piece.CurrentPosition.Y)
            {
                for (int i = currentBoardIndex - 8; i > targetBoardIndex; i -= 8)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move down
            else
            {
                for (int i = currentBoardIndex + 8; i < targetBoardIndex; i += 8)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }

            return canMove;
        }
    }
}