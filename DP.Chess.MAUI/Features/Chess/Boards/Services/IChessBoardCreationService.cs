namespace DP.Chess.MAUI.Features.Chess.Boards.Services
{
    /// <summary>
    /// Interface for creating a new chess board.
    /// </summary>
    public interface IChessBoardCreationService
    {
        /// <summary>
        /// Method for creating a chessboard for a new game of chess.
        /// </summary>
        IChessBoard CreateChessBoard();
    }
}