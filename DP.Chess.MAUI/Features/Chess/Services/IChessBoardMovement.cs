using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Interface for services that contain movement logic specific for chess pieces.
    /// </summary>
    public interface IChessBoardMovementService
    {
        /// <summary>
        /// Method that checks if a selected piece can move to a given cell.
        /// </summary>
        /// <param name="board">The game board on which the piece should move.</param>
        /// <param name="piece">The piece that wants to move.</param>
        /// <param name="targetCell">The target cell of the move.</param>
        /// <returns>
        /// True if the piece can move to the target cell, otherwise false.
        /// </returns>
        bool CanMove(IChessBoard board, IChessPiece piece, IChessCell targetCell);

        /// <summary>
        /// Moves a piece on the board from a source cell to a new cell.
        /// </summary>
        /// <param name="piece">The piece that will be moved.</param>
        /// <param name="sourceCell">
        /// The piece's source cell, it will move from here.
        /// </param>
        /// <param name="targetCell">
        /// The piece's target cell, it will move to here.
        /// </param>
        void Move(IChessPiece piece, IChessCell sourceCell, IChessCell targetCell);
    }
}