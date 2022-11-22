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
        }

        public ColorSet Color { get; }

        public Position CurrentPosition { get; set; }

        public Position[] PossibleMoveSet { get; protected set; }

        public string Symbol { get; }

        public abstract bool CheckTargetPosition(CellModel[] board, CellModel targetCell);

        public abstract void UpdatePossibleMoveSet();
    }
}