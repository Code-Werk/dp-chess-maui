using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Boards.Services;
using DP.Chess.MAUI.Features.Chess.Cells;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Class representing a chess board. It implements the
    /// <see cref="ObservableObject" /> class to notify any observers of its
    /// instances (e.g. the UI).
    /// </summary>
    public class ChessViewModel : ObservableObject
    {
        private readonly IChessBoardCreationService _chessBoardCreationService;
        private readonly IChessBoardMovementService _chessBoardMovementService;
        private readonly IChessGameStateService _chessGameStateService;

        private IChessBoard _board;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessViewModel" /> class.
        /// </summary>
        /// <param name="chessBoardCreationService">
        /// The service containing the chess board creation logic.
        /// </param>
        /// <param name="chessBoardMovementService">
        /// The service containing the chess board movement logic.
        /// </param>
        /// <param name="chessGameStateService">
        /// The service containing the game state logic.
        /// </param>
        /// <param name="board">The board where the game of chess takes place.</param>
        public ChessViewModel(
            IChessBoardCreationService chessBoardCreationService,
            IChessBoardMovementService chessBoardMovementService,
            IChessGameStateService chessGameStateService,
            IChessBoard board)
        {
            _chessBoardCreationService = chessBoardCreationService;
            _chessBoardMovementService = chessBoardMovementService;
            _chessGameStateService = chessGameStateService;
            _board = board;
        }

        /// <summary>
        /// Gets or sets the flag to indicate that one of the two players won.
        /// </summary>
        public IChessBoard Board
        {
            get => _board;
            set => SetProperty(ref _board, value);
        }

        #region ChessMoveCommand

        private ICommand? _chessMoveCommand;

        /// <summary>
        /// Gets the command that is executed to make a chess move (Schachzug)
        /// in the game. A complete chess turn executes this command twice, once
        /// to select the piece that should be moved, and a second time to move
        /// the piece to the desired position. The move may contain taking an
        /// opponent piece or not.
        /// </summary>
        public ICommand ChessMoveCommand => _chessMoveCommand
            ??= new RelayCommand<IChessCell>(x => _chessBoardMovementService.MoveSelectedPiece(Board, x), (_) => !Board.PlayerWon);

        #endregion ChessMoveCommand

        #region LoadCommand

        private ICommand? _loadCommand;

        /// <summary>
        /// Gets the command that is executed to load a previously saved game.
        /// It allows the user to pick a save file, which will then be loaded
        /// and the board will be initialized accordingly.
        /// </summary>
        public ICommand LoadCommand => _loadCommand
            ??= new AsyncRelayCommand(() => _chessGameStateService.LoadGame(Board));

        #endregion LoadCommand

        #region UndoCommand

        private ICommand? _undoCommand;

        /// <summary>
        /// Command that is executed to undo a previously made chess move. It
        /// loads the state of the board from the previous move.
        /// </summary>
        public ICommand UndoCommand => _undoCommand
            ??= new AsyncRelayCommand(() => _chessGameStateService.UndoMovement(Board));

        #endregion UndoCommand

        #region RedoCommand

        private ICommand? _redoCommand;

        /// <summary>
        /// Command that is executed to redo a previously undone chess move. It
        /// loads the state of the board from the undone move.
        /// </summary>
        public ICommand RedoCommand => _redoCommand
            ??= new AsyncRelayCommand(() => _chessGameStateService.RedoMovement(Board));

        #endregion RedoCommand

        #region RestartCommand

        private ICommand? _restartCommand;

        /// <summary>
        /// Command that is executed to start a new game of chess.
        /// </summary>
        public ICommand RestartCommand => _restartCommand
            ??= new RelayCommand(StartNewGame);

        private void StartNewGame()
        {
            Board = _chessBoardCreationService.CreateChessBoard();
        }

        #endregion RestartCommand

        #region SaveCommand

        private ICommand? _saveCommand;

        /// <summary>
        /// Command that is executed to save the current state of the board into
        /// a save file.
        /// </summary>
        public ICommand SaveCommand => _saveCommand
            ??= new AsyncRelayCommand(() => _chessGameStateService.SaveGame(Board), () => !Board.PlayerWon);

        #endregion SaveCommand
    }
}