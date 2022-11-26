namespace DP.Chess.MAUI.Infrastructure.BoardFactory
{
    /// <summary>
    /// Interface representing a single cell (tile) on a game board.
    /// </summary>
    /// <typeparam name="T">Type of the game pieces moving on the cells.</typeparam>
    public interface ICell<T>
        where T : IPiece
    {
        /// <summary>
        /// Selects or deselects a cell, marking it as active.
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets the piece currently located on a cell. Returns null if
        /// no piece is present.
        /// </summary>
        public T? Piece { get; set; }

        /// <summary>
        /// Gets a cell's position on a game board.
        /// </summary>
        public Position Position { get; }
    }
}