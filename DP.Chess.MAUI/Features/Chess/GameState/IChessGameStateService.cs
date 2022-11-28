using DP.Chess.MAUI.Features.Chess.Boards;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Interface for services containing state as logic specific for a game of chess.
    /// </summary>
    public interface IChessGameStateService
    {
        /// <summary>
        /// Method to load a previously saved game of chess. Opens a file dialog
        /// and waits until a JSON file is selected. Then reads the file and
        /// restores the state of the game from the save file.
        /// </summary>
        /// <param name="board">The current state of the chess board.</param>
        /// <returns>The finished task.</returns>
        Task LoadGame(IChessBoard board);

        /// <summary>
        /// Method that negates the effects of a previously called
        /// <see cref="UndoMovement(IChessBoard)" /> method. It recreates the
        /// state of the chess board before the respective undo was called.
        /// </summary>
        /// <param name="board">The current state of the chess board.</param>
        /// <returns>The finished task.</returns>
        Task RedoMovement(IChessBoard board);

        /// <summary>
        /// Method to save the current game of chess as JSON. Opens a file
        /// dialog where the user can create a new file and select it as the
        /// target of the JSON representation of the game. Then writes the
        /// current state of the game into the file.
        /// </summary>
        /// <param name="board">The current state of the chess board.</param>
        /// <returns>The finished task.</returns>
        Task SaveGame(IChessBoard board);

        /// <summary>
        /// Method that undoes the last movement on a chess board.
        /// It restores the state of the chess board before the current move.
        /// </summary>
        /// <param name="board">The current state of the chess board.</param>
        /// <returns>The finished task.</returns>
        Task UndoMovement(IChessBoard board);
    }
}