using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Cells
{
    /// <summary>
    /// Interface representing a cell on a chess board.
    /// </summary>
    public interface IChessCell : ICell<IChessPiece>
    {
    }
}