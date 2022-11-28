using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Class representing the king chess piece.
    /// </summary>
    public class King : ChessPiece, IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="King" /> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">
        /// The position of a piece on the board that it has after creation.
        /// </param>
        public King(PlayerColor color, Position currentPosition)
            : base(color, currentPosition, "KI")
        {
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <param name="targetCell"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public override bool CheckTargetPosition(IChessBoard board, IChessCell targetCell)
        {
            IChessPiece? pieceAtTarget = board[targetCell.Position].Piece;

            return pieceAtTarget is null || Color != pieceAtTarget.Color;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public override void UpdatePossibleMoveSet()
        {
            List<Position> moveSet = new();

            int minX = CurrentPosition.X <= 0 ? 0 : CurrentPosition.X - 1;
            int maxX = CurrentPosition.X >= 8 ? 8 : CurrentPosition.X + 1;

            int minY = CurrentPosition.Y <= 0 ? 0 : CurrentPosition.Y - 1;
            int maxY = CurrentPosition.Y >= 8 ? 8 : CurrentPosition.Y + 1;

            for (int x = minX; x <= maxX; x++)
                for (int y = minY; y <= maxY; y++)
                {
                    Position newPosition = new(x, y);
                    if (newPosition != CurrentPosition)
                    {
                        moveSet.Add(newPosition);
                    }
                }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}