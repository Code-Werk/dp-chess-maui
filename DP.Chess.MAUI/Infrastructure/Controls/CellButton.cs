namespace DP.Chess.MAUI.Infrastructure.Controls
{
    public class CellButton : Button
    {
        // TODO implement content https://learn.microsoft.com/en-us/dotnet/maui/user-interface/handlers/create?view=net-maui-7.0

        public static readonly BindableProperty ContentProperty
            = BindableProperty.Create(nameof(Content), typeof(ContentView), typeof(CellButton), null);

        public ContentView Content
        {
            get => (ContentView)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }
    }
}