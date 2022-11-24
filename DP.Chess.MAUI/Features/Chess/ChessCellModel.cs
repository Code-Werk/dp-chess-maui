using CommunityToolkit.Mvvm.ComponentModel;

namespace DP.Chess.MAUI.Features.Chess
{
    public class ChessCellModel : ObservableObject, IChessCell
    {
        private bool _isSelected;
        private IChessPiece _piece;

        public ChessCellModel(Position position)
        {
            Position = position;
        }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public IChessPiece Piece
        {
            get => _piece;
            set => SetProperty(ref _piece, value);
        }

        public Position Position { get; }
    }
}