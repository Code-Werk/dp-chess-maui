using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Infrastructure;

namespace DP.Chess.MAUI.Features.Chess.Pieces
{
    /// <summary>
    /// Abstract class representing a chess piece.
    /// </summary>
    public abstract class ChessPiece : IChessPiece
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChessPiece" /> class.
        /// </summary>
        /// <param name="color">The color of a piece.</param>
        /// <param name="currentPosition">
        /// The position of a piece on the board it has at creation.
        /// </param>
        /// <param name="symbol">The symbol representing a piece.</param>
        public ChessPiece(PlayerColor color, Position currentPosition, string symbol)
        {
            Color = color;
            CurrentPosition = currentPosition;
            Symbol = symbol;

            PossibleMoveSet = Array.Empty<Position>();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public PlayerColor Color { get; }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Position CurrentPosition { get; set; }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Position[] PossibleMoveSet { get; protected set; }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string Symbol { get; }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public abstract bool CheckTargetPosition(IChessBoard board, IChessCell targetCell);

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public abstract void UpdatePossibleMoveSet();
    }
}