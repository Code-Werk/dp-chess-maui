using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.Chess;

namespace DP.Chess.MAUI.Features
{
    /// <summary>
    /// Class containing UI logic for the <see cref="MainPageViewModel"/>.
    /// It implements the <see cref="ObservableObject"/> class to notify
    /// any observers of its instances (e.g. the UI).
    /// </summary>
    public class MainPageViewModel : ObservableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        /// <param name="movementService">The service containing chess piece movement logic.</param>
        public MainPageViewModel(IChessBoardMovementService movementService)
        {
            Board = new ChessBoard(movementService);
        }

        /// <summary>
        /// Gets or sets the instance of the game board.
        /// </summary>
        public object Board { get; }
    }
}