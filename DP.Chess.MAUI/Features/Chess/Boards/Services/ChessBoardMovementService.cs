using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure.Memento;
using DP.Chess.MAUI.Resources.I18N;

namespace DP.Chess.MAUI.Features.Chess.Boards.Services
{
    /// <summary>
    /// Class containing movement logic specific for chess.
    /// </summary>
    public class ChessBoardMovementService : IChessBoardMovementService
    {
        private readonly IMementoPersistCaretaker<ChessMemento> _mementoPersistCaretaker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoardMovementService"/> class.
        /// </summary>
        /// <param name="mementoPersistCaretaker">
        /// The memento used to store the state(s) of a game of chess.
        /// </param>
        public ChessBoardMovementService(
            IMementoPersistCaretaker<ChessMemento> mementoPersistCaretaker)
        {
            _mementoPersistCaretaker = mementoPersistCaretaker;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <param name="target"><inheritdoc /></param>
        public void MoveSelectedPiece(IChessBoard board, IChessCell? target)
        {
            if (target is null)
            {
                return;
            }

            bool pieceSelected = board.SelectedCell is not null && board.SelectedCell.Piece is not null;
            bool isTargeOwnPiece = target.Piece is not null && target.Piece.Color == board.CurrentPlayer;

            if (!pieceSelected && !isTargeOwnPiece)
            {
                RemoveCellSelection(board);
                return;
            }

            // chess piece to move was selected for the first time this move
            if (!pieceSelected)
            {
                SetSelected(board, target);
                return;
            }

            // player clicked on another piece of the same color
            if (board.SelectedCell!.Piece!.Color == target.Piece?.Color)
            {
                SetSelected(board, target);
                return;
            }

            try
            {
                if (!CanMove(board, target))
                {
                    IToast toast = Toast.Make(AppResources.General_InvalidMove_Label, ToastDuration.Short);
                    toast.Show();
                    return;
                }

                // check if the opponent king is the target of the move
                if (target.Piece is King)
                {
                    board.PlayerWon = true;
                    board.WinnerText = string.Format(AppResources.General_Winner_Label, board.CurrentPlayer);
                }

                // an empty field or one occupied by an opponent was selected
                Move(board.SelectedCell.Piece, board.SelectedCell, target);
                board.CurrentPlayer = board.CurrentPlayer == PlayerColor.White
                    ? PlayerColor.Black
                    : PlayerColor.White;

                _mementoPersistCaretaker.Add(board.SaveMemento());
            }
            finally
            {
                // reset the selected piece for the next move
                SetSelected(board, null);
            }
        }

        private static bool CanMove(IChessBoard board, IChessCell target)
        {
            IChessPiece? piece = board.SelectedCell?.Piece;

            if (piece is null)
            {
                return false;
            }

            piece.UpdatePossibleMoveSet();

            if (!piece.PossibleMoveSet.Contains(target.Position))
            {
                return false;
            }

            return piece.CheckTargetPosition(board, target);
        }

        private static void Move(IChessPiece piece, IChessCell source, IChessCell target)
        {
            piece.CurrentPosition = target.Position;
            source.Piece = null;
            target.Piece = piece;
        }

        private static void RemoveCellSelection(IChessBoard board)
        {
            foreach (IChessCell cell in board)
            {
                cell.IsSelected = false;
            }
        }

        private static void SetSelected(IChessBoard board, IChessCell? target)
        {
            board.SelectedCell = target;
            RemoveCellSelection(board);

            if (board.SelectedCell is not null)
            {
                board.SelectedCell.IsSelected = true;
            }
        }
    }
}