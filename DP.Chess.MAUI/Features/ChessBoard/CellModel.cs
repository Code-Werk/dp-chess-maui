using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.ChessBoard.Pieces;

namespace DP.Chess.MAUI.Features.ChessBoard
{
    public class CellModel : ObservableObject
    {
        private IChessPiece _chessPiece;
        private bool _isSelected;

        public CellModel(Position position)
        {
            Position = position;
        }

        public IChessPiece ChessPiece
        {
            get => _chessPiece;
            set => SetProperty(ref _chessPiece, value);
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public Position Position { get; }
    }
}