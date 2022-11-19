namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public interface IChessPiece
    {
        ColorSet Color { get; }

        Position CurrentPosition { get; }

        Position[] PossibleMoveSet { get; }

        string Symbol { get; }

        bool Move(Position p);
    }
}