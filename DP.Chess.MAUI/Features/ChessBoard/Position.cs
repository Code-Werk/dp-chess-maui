using System.Diagnostics.CodeAnalysis;

namespace DP.Chess.MAUI.Features.ChessBoard
{
    public readonly struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }

        public int Y { get; init; }

        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        public override bool Equals([NotNullWhen(true)] object o)
        {
            if (o is not Position p) return false;

            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}