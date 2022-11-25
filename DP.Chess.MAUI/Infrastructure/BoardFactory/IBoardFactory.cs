namespace DP.Chess.MAUI.Infrastructure.BoardFactory
{
    /// <summary>
    /// Abstract factory method for creating a board for a game.
    /// </summary>
    public interface IBoardFactory
    {
        /// <summary>
        /// Creates a new instance of a gaming board and returns a view
        /// representing this board.
        /// </summary>
        /// <returns>A board for the new start of a game.</returns>
        View CreateBoard();
    }
}