using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// Interface representing a chess board.
    /// </summary>
    public interface IChessBoard : IBoard<IChessCell, IChessPiece>
    {
    }
}