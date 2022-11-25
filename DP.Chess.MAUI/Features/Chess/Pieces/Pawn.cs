using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the pawn chess piece.
    /// </summary>
    public class Pawn : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pawn"/> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">The position of a piece on the board it has at creation.</param>
        public Pawn(PlayerColor color, Position currentPosition)
            : base(color, currentPosition, "P")
        {
        }

        private bool EndOfBoard => Color == PlayerColor.White && CurrentPosition.Y == 0
                    || Color == PlayerColor.Black && CurrentPosition.Y == 7;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            Position targetPosition = targetCell.Position;
            IChessPiece pieceAtTarget = board[targetPosition].Piece;

            // pawn is moving to take an enemy
            if (targetPosition.X != CurrentPosition.X)
            {
                return pieceAtTarget != null && Color != pieceAtTarget.Color;
            }

            // normal move
            bool canMove = true;
            canMove &= pieceAtTarget == null;

            // check special case where pawn can move upwards for two rows
            if (Color == PlayerColor.White && targetPosition.Y == CurrentPosition.Y - 2)
            {
                // check if there's a piece on the cell in between
                pieceAtTarget = board[targetPosition.X, targetPosition.Y - 1].Piece;
                canMove &= pieceAtTarget == null;
            }

            if (Color == PlayerColor.Black && targetPosition.Y == CurrentPosition.Y + 2)
            {
                // check if there's a piece on the cell in between
                pieceAtTarget = board[targetPosition.X, targetPosition.Y - 1].Piece;
                canMove &= pieceAtTarget == null;
            }

            return canMove;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            // Note: in this version if the game, pawns can not be exchanged
            // with queens when reaching the end of the board; they just can't
            // move anymore instead
            if (EndOfBoard)
            {
                PossibleMoveSet = moveSet.ToArray();
                return;
            }

            int newY = Color == PlayerColor.White
                ? CurrentPosition.Y - 1
                : CurrentPosition.Y + 1;

            moveSet.Add(new Position(CurrentPosition.X, newY));

            // add the diagonal fields for pawn take opponent logic
            moveSet.Add(new Position(CurrentPosition.X - 1, newY));
            moveSet.Add(new Position(CurrentPosition.X + 1, newY));

            // pawns can move either one or two fields in y direction on their
            // first move
            if (Color == PlayerColor.Black && CurrentPosition.Y == 1)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y + 2));
            }

            if (Color == PlayerColor.White && CurrentPosition.Y == 6)
            {
                moveSet.Add(new Position(CurrentPosition.X, CurrentPosition.Y - 2));
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}