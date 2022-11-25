using DP.Chess.MAUI.Features;
using DP.Chess.MAUI.Features.Chess;

namespace DP.Chess.MAUI.Infrastructure.Services
{
    /// <summary>
    /// Class containing extensions for the <see cref="MauiAppBuilder"/>
    /// to add dependencies to the application's service container.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method that registers the application's dependencies
        /// with the service container while building the application instance.
        /// </summary>
        /// <param name="mauiAppBuilder">The application's builder instance.</param>
        /// <returns>The application's builder instance.</returns>
        public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.RegisterServices();
            mauiAppBuilder.RegisterViewModels();
            mauiAppBuilder.RegisterViews();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IChessBoardMovementService, ChessBoardMovementService>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();

            return mauiAppBuilder;
        }
    }
}