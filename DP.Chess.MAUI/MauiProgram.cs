using DP.Chess.MAUI.Infrastructure.Services;
using Microsoft.Extensions.Logging;

namespace DP.Chess.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .RegisterDependencies();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}