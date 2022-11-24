namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    public abstract class ChessPiece : IChessPiece
    {
        public ChessPiece(ColorSet color, Position currentPosition, string symbol)
        {
            Color = color;
            CurrentPosition = currentPosition;
            Symbol = symbol;
        }

        public ColorSet Color { get; }

        public Position CurrentPosition { get; set; }

        public Position[] PossibleMoveSet { get; protected set; }

        public string Symbol { get; }

        public abstract bool CheckTargetPosition(IChessBoard board, IChessCell targetCell);

        public abstract void UpdatePossibleMoveSet();
    }
}