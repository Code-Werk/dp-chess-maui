namespace DP.Chess.MAUI.Infrastructure.BoardFactory
{
    /// <summary>
    /// Abstract factory method to create a board for a game.
    /// </summary>
    public interface IBoardFactory
    {
        /// <summary>
        /// Creates a new instance of a game board and returns a view
        /// representing this board.
        /// </summary>
        /// <returns>A board for the new start of a game.</returns>
        View CreateBoard();
    }
}