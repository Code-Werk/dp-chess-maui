namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Interface representing a game's board, consisting of cells where the game pieces move.
    /// </summary>
    /// <typeparam name="TCell">Type of the cells that the board consist of.</typeparam>
    /// <typeparam name="TPiece">Type of the game's pieces.</typeparam>
    public interface IBoard<TCell, TPiece> : IEnumerable<TCell>
        where TCell : ICell<TPiece>
        where TPiece : IPiece
    {
        /// <summary>
        /// Gets the cell at a given set of coordinates.
        /// </summary>
        /// <param name="x">The x coordinate of the cell on the board.</param>
        /// <param name="y">The y coordinate of the cell on the board.</param>
        /// <returns>The cell at the given coordinates.</returns>
        TCell this[int x, int y] { get; }

        /// <summary>
        /// Gets the cell at a given position.
        /// </summary>
        /// <param name="p">The position of the cell on the board.</param>
        /// <returns>The cell at the given position.</returns>
        TCell this[Position p] { get; }
    }
}