using DP.Chess.MAUI.Infrastructure.BoardFactory;

namespace DP.Chess.MAUI.Features;

/// <summary>
/// Class containing the code-behind for the <see cref="MainPage" />.
/// </summary>
public partial class MainPage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage" /> class.
    /// </summary>
    /// <param name="vm">View model containing UI logic for the <see cref="MainPage" />.</param>
    public MainPage(IBoardFactory boardFactory)
    {
        Content = new ScrollView()
        {
            Content = boardFactory.CreateBoard(),
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
        };
    }
}