using DP.Chess.MAUI.Features.Chess.Boards.Services;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// </summary>
    public class ChessBoardFactory : IBoardFactory
    {
        private readonly IChessBoardCreationService _chessBoardCreationService;
        private readonly IChessBoardMovementService _chessBoardMovementService;
        private readonly IChessGameStateService _chessGameStateService;

        public ChessBoardFactory(
            IChessBoardCreationService chessBoardCreationService,
            IChessBoardMovementService chessBoardMovementService,
            IChessGameStateService chessGameStateService)
        {
            _chessBoardCreationService = chessBoardCreationService;
            _chessBoardMovementService = chessBoardMovementService;
            _chessGameStateService = chessGameStateService;
        }

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