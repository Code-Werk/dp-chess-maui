namespace DP.Chess.MAUI.Features.Chess.Boards;

public partial class ChessBoardView : ContentView
{
    public ChessBoardView(ChessBoardViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}