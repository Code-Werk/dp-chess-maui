namespace DP.Chess.MAUI.Features.Chess.Boards.Services
{
    /// <summary>
    /// Interface for services containing the logic to create chess boards.
    /// </summary>
    public interface IChessBoardCreationService
    {
        /// <summary>
        /// Method to create the board for a new game of chess.
        /// </summary>
        /// <returns>The instance of the created <see cref="IChessBoard"/>.</returns>
        IChessBoard CreateChessBoard();
    }
}