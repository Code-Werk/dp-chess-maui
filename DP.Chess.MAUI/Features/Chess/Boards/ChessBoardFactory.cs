using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure;
using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features.Chess.Boards
{
    /// <summary>
    /// </summary>
    public class ChessBoardFactory : IBoardFactory
    {
        private readonly IChessFileService _fileService;
        private readonly IChessBoardMovementService _movementService;

        public ChessBoardFactory(
            IChessFileService fileService,
            IChessBoardMovementService movementService)
        {
            _fileService = fileService;
            _movementService = movementService;
        }

        public View CreateBoard()
        {
            ChessBoardViewModel vm = new(_fileService,
                _movementService,
                CreateChessBoardCells(),
                PlayerColor.White);
            return new ChessBoardView(vm);
        }

        /// <summary>
        /// Method that initializes an array of cells representing the start of
        /// a chess game.
        /// </summary>
        private static ChessCellModel[] CreateChessBoardCells()
        {
            ChessCellModel[] cells = new ChessCellModel[8 * 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Position position = new(x, y);
                    cells[position.ToChessBoardIndex()] = new ChessCellModel(position);
                }
            }

            for (int x = 0; x < 8; x++)
            {
                cells[8 + x].Piece = new Pawn(PlayerColor.Black, cells[8 + x].Position);
                cells[6 * 8 + x].Piece = new Pawn(PlayerColor.White, cells[6 * 8 + x].Position);
            }

            cells[0].Piece = new Rook(PlayerColor.Black, cells[0].Position);
            cells[7].Piece = new Rook(PlayerColor.Black, cells[7].Position);

            cells[7 * 8].Piece = new Rook(PlayerColor.White, cells[7 * 8].Position);
            cells[7 * 8 + 7].Piece = new Rook(PlayerColor.White, cells[7 * 8 + 7].Position);

            cells[1].Piece = new Knight(PlayerColor.Black, cells[1].Position);
            cells[6].Piece = new Knight(PlayerColor.Black, cells[6].Position);

            cells[7 * 8 + 1].Piece = new Knight(PlayerColor.White, cells[7 * 8 + 1].Position);
            cells[7 * 8 + 6].Piece = new Knight(PlayerColor.White, cells[7 * 8 + 6].Position);

            cells[2].Piece = new Bishop(PlayerColor.Black, cells[2].Position);
            cells[5].Piece = new Bishop(PlayerColor.Black, cells[5].Position);

            cells[7 * 8 + 2].Piece = new Bishop(PlayerColor.White, cells[7 * 8 + 2].Position);
            cells[7 * 8 + 5].Piece = new Bishop(PlayerColor.White, cells[7 * 8 + 5].Position);

            cells[3].Piece = new King(PlayerColor.Black, cells[3].Position);
            cells[7 * 8 + 3].Piece = new King(PlayerColor.White, cells[7 * 8 + 3].Position);

            cells[4].Piece = new Queen(PlayerColor.Black, cells[4].Position);
            cells[7 * 8 + 4].Piece = new Queen(PlayerColor.White, cells[7 * 8 + 4].Position);

            return cells;
        }
    }
}