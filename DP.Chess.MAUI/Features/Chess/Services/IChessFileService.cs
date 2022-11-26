using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;

namespace DP.Chess.MAUI.Features.Chess
{
    public interface IChessFileService
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Task<(PlayerColor currentPlayer, IList<IChessPiece> pieces)> LoadGame();

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        Task SaveGame(PlayerColor currentPlayer, IChessCell[] board);
    }
}