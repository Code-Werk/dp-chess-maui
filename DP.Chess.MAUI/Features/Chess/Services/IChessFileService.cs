using DP.Chess.MAUI.Features.Chess.Cells;

namespace DP.Chess.MAUI.Features.Chess
{
    public interface IChessFileService
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Task<(PlayerColor currentPlayer, IChessCell[] board)> LoadGame();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        Task SaveGame(PlayerColor currentPlayer, IChessCell[] board);
    }
}