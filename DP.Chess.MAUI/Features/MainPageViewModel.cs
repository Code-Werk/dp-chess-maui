using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.ChessBoard;
using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features
{
    public class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel()
        {
            Cells = new CellModel[8 * 8];
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                    Cells[y * 8 + x] = new CellModel(new Position(x, y));

            InitBoard();
        }

        public CellModel[] Cells { get; }

        public void InitBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                Cells[8 + x].ChessPiece = new Pawn(ColorSet.Black, Cells[x].Position);
                Cells[6 * 8 + x].ChessPiece = new Pawn(ColorSet.White, Cells[x].Position);
            }

            Cells[0].ChessPiece = new Rook(ColorSet.Black, Cells[0].Position);
            Cells[7].ChessPiece = new Rook(ColorSet.Black, Cells[7].Position);

            Cells[7 * 8].ChessPiece = new Rook(ColorSet.White, Cells[7 * 8].Position);
            Cells[7 * 8 + 7].ChessPiece = new Rook(ColorSet.White, Cells[7 * 8 + 7].Position);

            Cells[1].ChessPiece = new Knight(ColorSet.Black, Cells[1].Position);
            Cells[6].ChessPiece = new Knight(ColorSet.Black, Cells[6].Position);

            Cells[7 * 8 + 1].ChessPiece = new Knight(ColorSet.White, Cells[7 * 8 + 1].Position);
            Cells[7 * 8 + 6].ChessPiece = new Knight(ColorSet.White, Cells[7 * 8 + 6].Position);

            Cells[2].ChessPiece = new Bishop(ColorSet.Black, Cells[2].Position);
            Cells[5].ChessPiece = new Bishop(ColorSet.Black, Cells[5].Position);

            Cells[7 * 8 + 2].ChessPiece = new Bishop(ColorSet.White, Cells[7 * 8 + 2].Position);
            Cells[7 * 8 + 5].ChessPiece = new Bishop(ColorSet.White, Cells[7 * 8 + 5].Position);

            Cells[3].ChessPiece = new King(ColorSet.Black, Cells[3].Position);
            Cells[7 * 8 + 3].ChessPiece = new King(ColorSet.White, Cells[7 * 8 + 3].Position);

            Cells[4].ChessPiece = new Queen(ColorSet.Black, Cells[4].Position);
            Cells[7 * 8 + 4].ChessPiece = new Queen(ColorSet.White, Cells[7 * 8 + 4].Position);
        }
    }
}