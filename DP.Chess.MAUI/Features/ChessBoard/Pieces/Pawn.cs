namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Pawn : ChessPiece, IChessPiece
    {
        public Pawn(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "P")
        {
        }

        private bool EndOfBoard => Color == ColorSet.White && CurrentPosition.Y == 0
                    || Color == ColorSet.Black && CurrentPosition.Y == 7;

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            Position targetPosition = targetCell.Position;
            IChessPiece piece = board[targetPosition.ToBoardIndex()].ChessPiece;

            // pawn is moving to take an enemy
            if (targetPosition.X != CurrentPosition.X)
            {
                return piece != null && Color != piece.Color;
            }

            // normal move
            bool canMove = true;
            canMove |= piece == null;

            // check special case where pawn can move upwards for two rows
            if (Color == ColorSet.White && targetPosition.Y == CurrentPosition.Y - 2)
            {
                // check if there's a piece on the cell in between
                piece = board[targetPosition.ToBoardIndex() - 8].ChessPiece;
                canMove |= piece == null;
            }

            if (Color == ColorSet.Black && targetPosition.Y == CurrentPosition.Y + 2)
            {
                // check if there's a piece on the cell in between
                piece = board[targetPosition.ToBoardIndex() + 8].ChessPiece;
                canMove |= piece == null;
            }

            return canMove;
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // Note: in this version if the game, pawns can not be exchanged with queens
            // when reaching the end of the board; they just can't move anymore instead
            if (EndOfBoard)
            {
                PossibleMoveSet = moveSet.ToArray();
                return;
            }

            int newY = Color == ColorSet.White
                ? CurrentPosition.Y - 1
                : CurrentPosition.Y + 1;

            moveSet.Add(new Position(CurrentPosition.X, newY));

            // add the diagonal fields for pawn take opponent logic
            moveSet.Add(new Position(CurrentPosition.X - 1, newY));
            moveSet.Add(new Position(CurrentPosition.X + 1, newY));

            // pawns can move either one or two fields in y direction on their first move
            if (Color == ColorSet.Black && CurrentPosition.Y == 1)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y + 2));
            }

            if (Color == ColorSet.White && CurrentPosition.Y == 6)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y - 2));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}