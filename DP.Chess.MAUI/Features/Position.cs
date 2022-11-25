using System.Diagnostics.CodeAnalysis;

namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Structure representing a position with x and y coordinates on a game board.
    /// </summary>
    public readonly struct Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> structure.
        /// </summary>
        /// <param name="x">The x coordinate of the position on the board.</param>
        /// <param name="y">The y coordinate of the position on the board.</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the x coordinate of the position on the board.
        /// </summary>
        public int X { get; init; }

        /// <summary>
        /// Gets or sets the x coordinate of the position on the board.
        /// </summary>
        public int Y { get; init; }

        /// <summary>
        /// Method that compares two positions and checks if the positions are different.
        /// </summary>
        /// <param name="left">The first position to be compared.</param>
        /// <param name="right">The first position to be compared.</param>
        /// <returns>True if the positions are not equal, false otherwise.</returns>
        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Method that compares two positions and checks if the positions are equal.
        /// </summary>
        /// <param name="left">The first position to be compared.</param>
        /// <param name="right">The first position to be compared.</param>
        /// <returns>True if the positions are equal, false otherwise.</returns>
        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="o"><inheritdoc/></param>
        /// <returns><inheritdoc/></returns>
        public override bool Equals([NotNullWhen(true)] object o)
        {
            if (o is not Position p) return false;

            return (X == p.X) && (Y == p.Y);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns><inheritdoc/></returns>
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}