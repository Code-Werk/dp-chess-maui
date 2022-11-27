using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Interface for services containing file I/O logic specific for a game of chess.
    /// </summary>
    public interface IChessFileService
    {
        /// <summary>
        /// Method to load a previously saved game of chess.
        /// <br />
        /// Opens a file dialog and waits until a JSON file is selected.
        /// Then reads the file and restores the state of the game from
        /// the save file.
        /// </summary>
        /// <returns>A tuple containing the current player and the state of the board.
        /// Null if the loading process was canceled.</returns>
        Task<(PlayerColor currentPlayer, IList<IChessPiece> pieces)?> LoadGame();

        /// <summary>
        /// Method to save the current game of chess as JSON.
        /// <br />
        /// Opens a file dialog where the user can create a new file and select
        /// it as the target if the JSON representation of the game. Then writes the
        /// current state of the game into the file.
        /// </summary>
        /// <param name="currentPlayer">The player that is currently playing.</param>
        /// <param name="board">The current version of the chess board.</param>
        /// <returns>True if saving was successful, otherwise false.</returns>
        Task<bool> SaveGame(PlayerColor currentPlayer, IChessCell[] board);
    }
}