namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public interface IChessPiece
    {
        ColorSet Color { get; }

        Position CurrentPosition { get; set; }

        Position[] PossibleMoveSet { get; }

        string Symbol { get; }

        void UpdatePossibleMoveSet();
    }
}