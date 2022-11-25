namespace DP.Chess.MAUI;

/// <summary>
/// Partial class for the root page of MAUI application.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}