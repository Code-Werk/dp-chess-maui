using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess
{
    internal static class ChessPositionExtensions
    {
        /// <summary>
        /// Method that calculates the index of a cell in an one dimensional
        /// array, by a position.
        /// </summary>
        /// <param name="position">The base of the index calculation.</param>
        /// <returns>The one dimensional index of a position.</returns>
        internal static int ToChessBoardIndex(this Position position)
        {
            return position.Y * 8 + position.X;
        }
    }
}