using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure;
using DP.Chess.MAUI.Infrastructure.Memento;

namespace DP.Chess.MAUI.Features.Chess.Boards.Services
{
    /// <summary>
    /// Class for creating a new chess board.
    /// </summary>
    public class ChessBoardCreationService : IChessBoardCreationService
    {
        private readonly IMementoPersistCaretaker<ChessMemento> _mementoPersistCaretaker;

        public ChessBoardCreationService(IMementoPersistCaretaker<ChessMemento> mementoPersistCaretaker)
        {
            _mementoPersistCaretaker = mementoPersistCaretaker;
        }

        public IChessBoard CreateChessBoard()
        {
            ChessBoardModel board = new(CreateCells(), PlayerColor.White);

            _mementoPersistCaretaker.Clear();
            _mementoPersistCaretaker.Add(board.SaveMemento());
            return board;
        }

        /// <summary>
        /// Method that creates for each tile in a chessboard of size 8x8 a new
        /// <see cref="ChessCellModel" /> representing that tile.
        /// </summary>
        /// <returns>
        /// An array of <see cref="ChessCellModel" /> representing a chess board.
        /// </returns>
        private static ChessCellModel[] CreateCells()
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