using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure.BoardFactory;
using DP.Chess.MAUI.Infrastructure.Memento;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// Interface representing a chess board.
    /// </summary>
    public interface IChessBoard : IBoard<IChessCell, IChessPiece>, IMementoOriginator<ChessMemento>
    {
        PlayerColor CurrentPlayer { get; set; }

        bool PlayerWon { get; set; }

        IChessCell? SelectedCell { get; set; }

        string WinnerText { get; set; }
    }
}