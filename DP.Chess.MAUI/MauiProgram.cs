using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using DP.Chess.MAUI.Infrastructure.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

#if WINDOWS

using Microsoft.UI;
using Microsoft.UI.Windowing;

#endif

namespace DP.Chess.MAUI;

/// <summary>
/// Class that serves as the entry point for the MAUI application.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Static method that creates the MAUI application instance.
    /// </summary>
    /// <returns>The application instance.</returns>
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp
            .CreateBuilder()
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("materialdesignicons-webfont.ttf", "MDI");
            })
            .RegisterDependencies();

#if WINDOWS
        // open in full screen
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(lifecycleBuilder =>
            {
                lifecycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId winId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    AppWindow appWindow = AppWindow.GetFromWindowId(winId);

                    switch (appWindow.Presenter)
                    {
                        case OverlappedPresenter overlappedPresenter:
                            overlappedPresenter.SetBorderAndTitleBar(false, false);
                            overlappedPresenter.Maximize();
                            break;
                    }
                });
            });
        });
#endif

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}