using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Resources.I18N;
using DP.Chess.MAUI.Infrastructure;
using System.Collections;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// Class representing a chess board. It implements the
    /// <see cref="ObservableObject" /> class to notify any observers of its
    /// instances (e.g. the UI).
    /// </summary>
    public class ChessBoardViewModel : ObservableObject, IEnumerable<IChessCell>, IChessBoard
    {
        private readonly IChessCell[] _cells;
        private readonly IChessBoardMovementService _movementService;

        private PlayerColor _currentPlayer;
        private bool _playerWon;
        private IChessPiece _selectedPiece;
        private string _winnerText;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessBoardViewModel" /> class.
        /// </summary>
        /// <param name="movementService">
        /// The service containing chess piece movement logic.
        /// </param>
        public ChessBoardViewModel(IChessBoardMovementService movementService, IChessCell[] cells, PlayerColor startingPlayer)
        {
            _cells = cells;
            _currentPlayer = startingPlayer;
            _movementService = movementService;
        }

        /// <summary>
        /// Gets or sets the player that is currently making a move.
        /// </summary>
        public PlayerColor CurrentPlayer
        {
            get => _currentPlayer;
            set => SetProperty(ref _currentPlayer, value);
        }

        /// <summary>
        /// Gets or sets the flag to indicate that one of the two players won.
        /// </summary>
        public bool PlayerWon
        {
            get => _playerWon;
            set => SetProperty(ref _playerWon, value);
        }

        /// <summary>
        /// Gets or sets the text displaying the winner of the current game.
        /// </summary>
        public string WinnerText
        {
            get => _winnerText;
            set => SetProperty(ref _winnerText, value);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IChessCell this[int x, int y] => _cells[y * 8 + x];

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IChessCell this[Position p] => _cells[p.ToChessBoardIndex()];

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerator<IChessCell> GetEnumerator() => _cells.Cast<IChessCell>().GetEnumerator();

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => _cells.GetEnumerator();

        /// <summary>
        /// Method that initializes the chess board for a new game.
        /// </summary>

        private void RemoveCellSelection()
        {
            foreach (IChessCell cell in this)
            {
                cell.IsSelected = false;
            }
        }

        #region ChessMoveCommand

        private ICommand _chessMoveCommand;

        /// <summary>
        /// Gets the command that is executed to make a chess move (Schachzug)
        /// in the game. A complete chess turn executes this command twice, once
        /// to select the piece that should be moved, and a second time to move
        /// the piece to the desired position. The move may contain taking an
        /// opponent piece or not.
        /// </summary>
        public ICommand ChessMoveCommand => _chessMoveCommand
            ??= new RelayCommand<IChessCell>(DoChessMove, (IChessCell _) => !PlayerWon);

        private void DoChessMove(IChessCell cell)
        {
            if (_selectedPiece == null
                && (cell.Piece == null || cell.Piece.Color != CurrentPlayer))
            {
                RemoveCellSelection();
                return;
            }

            // chess piece to move was selected for the first time this move
            if (_selectedPiece == null)
            {
                _selectedPiece = cell.Piece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            // player clicked on another piece of the same color
            if (_selectedPiece.Color == cell.Piece?.Color)
            {
                _selectedPiece = cell.Piece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            try
            {
                if (!_movementService.CanMove(this, _selectedPiece, cell))
                {
                    IToast toast = Toast.Make(AppResources.General_InvalidMove_Label, ToastDuration.Short);
                    toast.Show();
                    return;
                }

                // check if the opponent king is the target of the move
                if (cell.Piece is King)
                {
                    PlayerWon = true;
                    WinnerText = string.Format(AppResources.General_Winner_Label, CurrentPlayer);
                }

                // an empty field or one occupied by an opponent was selected
                _movementService.Move(_selectedPiece, this[_selectedPiece.CurrentPosition], cell);
                CurrentPlayer = CurrentPlayer == PlayerColor.White
                    ? PlayerColor.Black
                    : PlayerColor.White;
            }
            finally
            {
                // reset the selected piece for the next move
                RemoveCellSelection();
                _selectedPiece = null;
            }
        }

        #endregion ChessMoveCommand

        #region LoadCommand

        private ICommand _loadCommand;

        /// <summary>
        /// Gets the command that is executed to load a previously saved game.
        /// It allows the user to pick a save file, which will then be loaded
        /// and the board will be initialized accordingly.
        /// </summary>
        public ICommand LoadCommand => _loadCommand
            ??= new AsyncRelayCommand(LoadGame);

        private async Task LoadGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion LoadCommand

        #region UndoCommand

        private ICommand _undoCommand;

        /// <summary>
        /// Command that is executed to undo a previously made chess move. It
        /// loads the state of the board from the previous move.
        /// </summary>
        public ICommand UndoCommand => _undoCommand
            ??= new RelayCommand(UndoMove);

        private void UndoMove()
        {
            // TODO: implement memento pattern
        }

        #endregion UndoCommand

        #region RedoCommand

        private ICommand _redoCommand;

        /// <summary>
        /// Command that is executed to redo a previously undone chess move. It
        /// loads the state of the board from the undone move.
        /// </summary>
        public ICommand RedoCommand => _redoCommand
            ??= new RelayCommand(RedoMove);

        private void RedoMove()
        {
            // TODO: implement memento pattern
        }

        #endregion RedoCommand

        #region RestartCommand

        private ICommand _restartCommand;

        /// <summary>
        /// Command that is executed to start a new game of chess.
        /// </summary>
        public ICommand RestartCommand => _restartCommand
            ??= new RelayCommand(RestartGame);

        private void RestartGame()
        {
            foreach (IChessCell c in _cells)
            {
                c.Piece = null;
            }

            InitBoard();
            RemoveCellSelection();
            CurrentPlayer = ColorSet.White;
            PlayerWon = false;
            WinnerText = string.Empty;

            // TODO: reset the state
        }

        #endregion RestartCommand

        #region SaveCommand

        private ICommand _saveCommand;

        /// <summary>
        /// Command that is executed to save the current state of the board into
        /// a save file.
        /// </summary>
        public ICommand SaveCommand => _saveCommand
            ??= new AsyncRelayCommand(SaveGame);

        private async Task SaveGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion SaveCommand
    }
}