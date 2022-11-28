using DP.Chess.MAUI.Features.Chess.Cells;

namespace DP.Chess.MAUI.Features.Chess.Boards.Services
{
    /// <summary>
    /// Interface for services that contain movement logic specific for chess.
    /// </summary>
    public interface IChessBoardMovementService
    {
        /// <summary>
        /// Moves a piece on the board from a source cell to a target cell.
        /// </summary>
        /// <param name="board">
        /// The board where the piece should be moved. It contains the selected piece.
        /// </param>
        /// <param name="target">The piece's target cell, it will move to here.</param>
        void MoveSelectedPiece(IChessBoard board, IChessCell? target);
    }
}