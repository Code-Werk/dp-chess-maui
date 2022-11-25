namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Interface for services that contain movement logic for game pieces.
    /// </summary>
    /// <typeparam name="TBoard">Type of the game board.</typeparam>
    /// <typeparam name="TCell">Type of the cells on the game board.</typeparam>
    /// <typeparam name="TPiece">Type of the piece for which the service contains movement logic.</typeparam>
    public interface IMovementService<TBoard, TCell, TPiece>
        where TBoard : IBoard<TCell, TPiece>
        where TCell : ICell<TPiece>
        where TPiece : IPiece
    {
        /// <summary>
        /// Method that checks if a selected piece can move to a given cell.
        /// </summary>
        /// <param name="board">The game board on which the piece should move.</param>
        /// <param name="piece">The piece that wants to move.</param>
        /// <param name="targetCell">The target cell of the move.</param>
        /// <returns>True if the piece can move to the target cell, otherwise false.</returns>
        bool CanMove(TBoard board, TPiece piece, TCell targetCell);

        /// <summary>
        /// Moves a piece on the board from a source cell to a new cell.
        /// </summary>
        /// <param name="piece">The piece that will be moved.</param>
        /// <param name="sourceCell">The piece's source cell, it will move from here.</param>
        /// <param name="targetCell">The piece's target cell, it will move to here.</param>
        void Move(TPiece piece, TCell sourceCell, TCell targetCell);
    }
}