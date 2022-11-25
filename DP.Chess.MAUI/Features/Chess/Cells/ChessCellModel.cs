using CommunityToolkit.Mvvm.ComponentModel;
using DP.Chess.MAUI.Features.Chess.Pieces;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Cells
{
    /// <summary>
    /// Class representing a cell on a chess board. It implements the
    /// <see cref="ObservableObject" /> class to notify any observers of its
    /// instances (e.g. the UI).
    /// </summary>
    public class ChessCellModel : ObservableObject, IChessCell
    {
        private bool _isSelected;
        private IChessPiece _piece;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessCellModel" /> class.
        /// </summary>
        /// <param name="position">The position of the cell on a chess board.</param>
        public ChessCellModel(Position position)
        {
            Position = position;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IChessPiece Piece
        {
            get => _piece;
            set => SetProperty(ref _piece, value);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Position Position { get; }
    }
}