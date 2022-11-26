namespace DP.Chess.MAUI.Features.Chess.Services
{
    public interface IChessFileService
    {
        Task<(ColorSet currentPlayer, IChessCell[] board)> LoadGame();

        Task SaveGame(ColorSet currentPlayer, IChessCell[] board);
    }
}