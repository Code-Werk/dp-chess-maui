using DP.Chess.MAUI.Features.Chess.Boards.Services;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// Class containing the implementation of the <see cref="IBoardFactory"/> to create chess boards.
    /// </summary>
    public class ChessBoardFactory : IBoardFactory
    {
        private readonly IChessBoardCreationService _chessBoardCreationService;
        private readonly IChessBoardMovementService _chessBoardMovementService;
        private readonly IChessGameStateService _chessGameStateService;

        /// <summary>
        /// Initializes a new instance if the <see cref="ChessBoardFactory"/> class.
        /// <param name="chessBoardCreationService">
        /// The service containing the chess board creation logic.
        /// </param>
        /// <param name="chessBoardMovementService">
        /// The service containing the chess board movement logic.
        /// </param>
        /// <param name="chessGameStateService">
        /// The service containing the chess game state logic.
        /// </param>
        public ChessBoardFactory(
            IChessBoardCreationService chessBoardCreationService,
            IChessBoardMovementService chessBoardMovementService,
            IChessGameStateService chessGameStateService)
        {
            _chessBoardCreationService = chessBoardCreationService;
            _chessBoardMovementService = chessBoardMovementService;
            _chessGameStateService = chessGameStateService;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns><inheritdoc /></returns>
        public View CreateBoard()
        {
            IChessBoard model = _chessBoardCreationService.CreateChessBoard();
            ChessViewModel vm = new(_chessBoardCreationService,
                _chessBoardMovementService,
                _chessGameStateService,
                model);

            return new ChessView(vm);
        }
    }
}