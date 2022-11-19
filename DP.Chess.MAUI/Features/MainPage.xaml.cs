namespace DP.Chess.MAUI.Features;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel vm)
    {
        BindingContext = vm;

        InitializeComponent();
    }
}