namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the knight chess piece.
    /// </summary>
    public class Knight : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight"/> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">The position of a piece on the board it has at creation.</param>
        public Knight(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "KN")
        {
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            IChessPiece pieceAtTarget = board[targetCell.Position].Piece;

            // the knight can jump over other pieces in its way, thus we do not
            // need to check for that
            return pieceAtTarget == null || Color != pieceAtTarget.Color;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // TODO: is there a better way?

            if (IsInRange(2, -1))
            {
                moveSet.Add(new Position(CurrentPosition.X + 2, CurrentPosition.Y - 1));
            }
            if (IsInRange(2, 1))
            {
                moveSet.Add(new Position(CurrentPosition.X + 2, CurrentPosition.Y + 1));
            }
            if (IsInRange(-2, -1))
            {
                moveSet.Add(new Position(CurrentPosition.X - 2, CurrentPosition.Y - 1));
            }
            if (IsInRange(-2, 1))
            {
                moveSet.Add(new Position(CurrentPosition.X - 2, CurrentPosition.Y + 1));
            }
            if (IsInRange(-1, 2))
            {
                moveSet.Add(new Position(CurrentPosition.X - 1, CurrentPosition.Y + 2));
            }
            if (IsInRange(1, 2))
            {
                moveSet.Add(new Position(CurrentPosition.X + 1, CurrentPosition.Y + 2));
            }
            if (IsInRange(-1, -2))
            {
                moveSet.Add(new Position(CurrentPosition.X - 1, CurrentPosition.Y - 2));
            }
            if (IsInRange(1, -2))
            {
                moveSet.Add(new Position(CurrentPosition.X + 1, CurrentPosition.Y - 2));
            }

            PossibleMoveSet = moveSet.ToArray();
        }

        private bool IsInRange(int moveX, int moveY)
        {
            int newX = CurrentPosition.X + moveX;
            bool validX = newX >= 0 && newX <= 7;

            int newY = CurrentPosition.Y + moveY;
            bool validY = newY >= 0 && newY <= 7;

            return validX && validY;
        }
    }
}