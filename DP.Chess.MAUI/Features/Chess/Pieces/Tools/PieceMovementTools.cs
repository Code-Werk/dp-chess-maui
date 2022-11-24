namespace DP.Chess.MAUI.Features.Chess.Pieces
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

        public static bool CheckDiagonalMovement(IChessPiece piece, IChessBoard board, Position targetPosition)
        {
            bool canMove = true;

            // move left
            if (targetPosition.X < piece.CurrentPosition.X)
            {
                // move up
                if (targetPosition.Y < piece.CurrentPosition.Y)
                {
                    for (int i = 1; i < piece.CurrentPosition.X - targetPosition.X; i++)
                    {
                        canMove &= board[piece.CurrentPosition.X - i, piece.CurrentPosition.Y - i].Piece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = 1; i < piece.CurrentPosition.X - targetPosition.X; i++)
                    {
                        canMove &= board[piece.CurrentPosition.X - i, piece.CurrentPosition.Y + i].Piece == null;
                    }
                }
            }
            // move right
            else
            {
                // move up
                if (targetPosition.Y < piece.CurrentPosition.Y)
                {
                    for (int i = 1; i < targetPosition.X - piece.CurrentPosition.X; i++)
                    {
                        canMove &= board[piece.CurrentPosition.X + i, piece.CurrentPosition.Y - i].Piece == null;
                    }
                }
                // move down
                else
                {
                    for (int i = 1; i < targetPosition.X - piece.CurrentPosition.X; i++)
                    {
                        canMove &= board[piece.CurrentPosition.X + i, piece.CurrentPosition.Y + i].Piece == null;
                    }
                }
            }

            return canMove;
        }

        public static bool CheckStraightMovement(IChessPiece piece, IChessBoard board, Position target)
        {
            bool canMove = true;

            // move left
            if (target.X < piece.CurrentPosition.X)
            {
                for (int x = piece.CurrentPosition.X - 1; x > target.X; x--)
                {
                    canMove &= board[x, piece.CurrentPosition.Y].Piece == null;
                }
            }
            // move right
            else if (target.X > piece.CurrentPosition.X)
            {
                for (int x = piece.CurrentPosition.X + 1; x < target.X; x++)
                {
                    canMove &= board[x, piece.CurrentPosition.Y].Piece == null;
                }
            }
            // move up
            else if (target.Y < piece.CurrentPosition.Y)
            {
                for (int y = piece.CurrentPosition.Y - 1; y > target.Y; y--)
                {
                    canMove &= board[piece.CurrentPosition.X, y].Piece == null;
                }
            }
            // move down
            else
            {
                for (int y = piece.CurrentPosition.Y + 1; y < target.Y; y++)
                {
                    canMove &= board[piece.CurrentPosition.X, y].Piece == null;
                }
            }

            return canMove;
        }
    }
}