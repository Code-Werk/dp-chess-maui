namespace DP.Chess.MAUI.Features
{
    public interface IPiece
    {
        Position CurrentPosition { get; set; }

        Position[] PossibleMoveSet { get; }

        string Symbol { get; }
    }
}