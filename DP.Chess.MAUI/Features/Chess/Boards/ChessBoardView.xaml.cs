namespace DP.Chess.MAUI.Features.Chess.Boards;

/// <summary>
/// Class containing the code-behind for the <see cref="MainPage" />.
/// </summary>
public partial class ChessBoardView : ContentView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChessBoardView" /> class.
    /// </summary>
    /// <param name="vm">The view model containing UI logic for the <see cref="ChessBoardView"/>.</param>
    public ChessBoardView(ChessBoardViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}