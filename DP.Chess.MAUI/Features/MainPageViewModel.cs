using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.Chess;

namespace DP.Chess.MAUI.Features
{
    public class MainPageViewModel : ObservableObject
    {
        public MainPageViewModel(IChessBoardMovementService movementService)
        {
            Board = new ChessBoard(movementService);
        }

        public object Board { get; }
    }
}