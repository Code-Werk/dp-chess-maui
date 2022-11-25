namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Class that contains movement logic specific for chess pieces.
    /// </summary>
    public class ChessBoardMovementService : IChessBoardMovementService
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool CanMove(IChessBoard board, IChessPiece piece, IChessCell target)
        {
            piece.UpdatePossibleMoveSet();

            if (!piece.PossibleMoveSet.Contains(target.Position))
            {
                return false;
            }

            return piece.CheckTargetPosition(board, target);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Move(IChessPiece piece, IChessCell source, IChessCell target)
        {
            piece.CurrentPosition = target.Position;
            source.Piece = null;
            target.Piece = piece;
        }
    }
}