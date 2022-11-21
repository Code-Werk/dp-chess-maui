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

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // TODO: add diagonal field(s) to move set if there is an opponent
            //if (piece != null && piece.Color != Color)
            //{
            //    PossibleMoveSet = PossibleMoveSet.Append(p).ToArray();
            //}

            // Note: in this version if the game, pawns can not be exchanged with queens
            // when reaching the end of the board; they just can't move anymore instead
            if (EndOfBoard)
            {
                PossibleMoveSet = moveSet.ToArray();
                return;
            }

            int newY = Color == ColorSet.White
                ? CurrentPosition.Y + 1
                : CurrentPosition.Y - 1;

            moveSet.Add(new Position(CurrentPosition.X, newY));

            // pawns can move either one or two fields in y direction on their first move
            if (Color == ColorSet.Black && CurrentPosition.Y == 1)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y + 2));
            }
            if (Color == ColorSet.Black && CurrentPosition.Y == 7)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y - 2));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}