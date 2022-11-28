using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Class containing extension methods for instances of the <see cref="Position"/> class.
    /// </summary>
    internal static class ChessPositionExtensions
    {
        /// <summary>
        /// Method that calculates the index of a cell in a one dimensional
        /// array from the position of that cell on a game board.
        /// </summary>
        /// <param name="position">The base of the index calculation.</param>
        /// <returns>The one dimensional index of a position.</returns>
        internal static int ToChessBoardIndex(this Position position)
        {
            return position.Y * 8 + position.X;
        }
    }
}