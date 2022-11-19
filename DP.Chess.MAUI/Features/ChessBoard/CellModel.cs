using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard
{
    public class CellModel : ObservableObject
    {
        private IChessPiece _chessPiece;

        public CellModel(Position position)
        {
            Position = position;
        }

        public IChessPiece ChessPiece
        {
            get => _chessPiece;
            set => SetProperty(ref _chessPiece, value);
        }

        public Position Position { get; }
    }
}