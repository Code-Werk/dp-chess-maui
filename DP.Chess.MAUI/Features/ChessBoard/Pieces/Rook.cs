namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Rook : ChessPiece, IChessPiece
    {
        public Rook(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "R")
        {
        }

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            bool canMove = true;
            int currentBoardIndex = CurrentPosition.ToBoardIndex();
            Position targetPosition = targetCell.Position;
            int targetBoardIndex = targetPosition.ToBoardIndex();

            IChessPiece pieceAtTarget = board[targetBoardIndex].ChessPiece;
            canMove &= pieceAtTarget == null || Color != pieceAtTarget?.Color;

            // TODO: cleanup if there's a better way
            // TODO: taking opponent not yet considered

            // move left
            if (targetPosition.X < CurrentPosition.X)
            {
                for (int i = currentBoardIndex - 1; i >= targetBoardIndex; i--)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move right
            else if (targetPosition.X > CurrentPosition.X)
            {
                for (int i = currentBoardIndex + 1; i <= targetBoardIndex; i++)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move up
            else if (targetPosition.Y < CurrentPosition.Y)
            {
                for (int i = currentBoardIndex - 8; i >= targetBoardIndex; i -= 8)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }
            // move down
            else
            {
                for (int i = currentBoardIndex + 8; i <= targetBoardIndex; i += 8)
                {
                    canMove &= board[i].ChessPiece == null;
                }
            }

            return canMove;
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

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}