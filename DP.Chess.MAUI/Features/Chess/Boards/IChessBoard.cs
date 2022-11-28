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
        /// <summary>
        /// Gets or sets the player that can currently make their move.
        /// </summary>
        PlayerColor CurrentPlayer { get; set; }

        /// <summary>
        /// Gets or sets the flag to indicate that one of the two players won.
        /// </summary>
        bool PlayerWon { get; set; }

        /// <summary>
        /// Gets or sets the cell that is currently selected.
        /// </summary>
        IChessCell? SelectedCell { get; set; }

        /// <summary>
        /// Gets or sets the text displaying the winner of the current game.
        /// </summary>
        string WinnerText { get; set; }
    }
}