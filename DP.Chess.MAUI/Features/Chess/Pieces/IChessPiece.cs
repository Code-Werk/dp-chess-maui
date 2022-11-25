using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Interface for a chess piece.
    /// </summary>
    public interface IChessPiece : IPiece
    {
        /// <summary>
        /// Gets the color (black or white) of a piece.
        /// </summary>
        PlayerColor Color { get; }

        /// <summary>
        /// Method that checks if a piece can move to a selected target cell.
        /// </summary>
        /// <param name="board">The board on which the piece moves.</param>
        /// <param name="target">The cell the piece wants to move to.</param>
        /// <returns>
        /// True if the piece can move to the target cell, otherwise false.
        /// </returns>
        bool CheckTargetPosition(IChessBoard board, IChessCell target);

        /// <summary>
        /// Method that updates the list of cells where a piece can move to in
        /// the next move.
        /// </summary>
        void UpdatePossibleMoveSet();
    }
}