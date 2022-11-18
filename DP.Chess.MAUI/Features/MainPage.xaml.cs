namespace DP.Chess.MAUI.Features;

public partial class MainPage : ContentPage
{
    private int count = 0;

    public MainPage(MainPageViewModel vm)
    {
        BindingContext = vm;

        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}