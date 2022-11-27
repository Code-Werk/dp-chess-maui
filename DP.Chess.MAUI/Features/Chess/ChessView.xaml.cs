namespace DP.Chess.MAUI.Features.Chess;

/// <summary>
/// Class containing the code-behind for the <see cref="ChessView" />.
/// </summary>
public partial class ChessView : ContentView
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChessView" /> class.
    /// </summary>
    /// <param name="vm">The view model containing UI logic for the <see cref="ChessView" />.</param>
    public ChessView(ChessViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}