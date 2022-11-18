namespace DP.Chess.MAUI.Features.ChessBoard;

public partial class ChessBoardView : ContentView
{
    public ChessBoardView(ChessBoardViewModel vm)
    {
        BindingContext = vm;

        InitializeComponent();
    }
}