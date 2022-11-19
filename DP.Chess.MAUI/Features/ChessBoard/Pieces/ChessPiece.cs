namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public enum ColorSet
    {
        Black = 0,
        White = 1
    }

    public abstract class ChessPiece : IChessPiece
    {
        public ChessPiece(ColorSet color, Position currentPosition, string symbol)
        {
            Color = color;
            CurrentPosition = currentPosition;
            Symbol = symbol;

            PossibleMoveSet = UpdateMoveSet();
        }

        public ColorSet Color { get; }

        public Position CurrentPosition { get; private set; }

        public Position[] PossibleMoveSet { get; private set; }

        public string Symbol { get; }

        public bool Move(Position p)
        {
            if (!PossibleMoveSet.Contains(p))
            {
                return false;
            }

            CurrentPosition = p;
            PossibleMoveSet = UpdateMoveSet();
            return true;
        }

        protected abstract Position[] UpdateMoveSet();
    }
}