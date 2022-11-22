using DP.Chess.MAUI.Features;
using DP.Chess.MAUI.Features.ChessBoard;

namespace DP.Chess.MAUI.Infrastructure.Services
{
    public static class ServiceExtensions
    {
        public static MauiAppBuilder RegisterDependencies(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.RegisterServices();
            mauiAppBuilder.RegisterViewModels();
            mauiAppBuilder.RegisterViews();

            return mauiAppBuilder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IMovementService, MovementService>();

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