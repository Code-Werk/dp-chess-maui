namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Interface for a piece used in games.
    /// </summary>
    public interface IPiece
    {
        /// <summary>
        /// Gets or sets the piece's <see cref="Position"/> on the game board.
        /// </summary>
        Position CurrentPosition { get; set; }

        /// <summary>
        /// Gets a list of positions that the piece could move to in the next turn.
        /// </summary>
        Position[] PossibleMoveSet { get; }

        /// <summary>
        /// Gets a symbol representing the piece on the game board.
        /// </summary>
        string Symbol { get; }
    }
}