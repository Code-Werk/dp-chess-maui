using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;
using System.Text.Json;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Service containing file I/O logic specific for a game of chess.
    /// </summary>
    public class ChessFileService : IChessFileService
    {
        private readonly PickOptions _filePickerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChessFileService"/> class.
        /// </summary>
        public ChessFileService()
        {
            _filePickerOptions = new()
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] {".json", ".txt"} }
                }),
            };
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public async Task<(PlayerColor currentPlayer, IList<IChessPiece> pieces)?> LoadGame()
        {
            FileResult? result = await FilePicker.Default.PickAsync(_filePickerOptions);
            if (result == null)
            {
                return null;
            }

            using Stream? stream = await result.OpenReadAsync();
            ChessSerializable? deserializedSave =
               await JsonSerializer.DeserializeAsync<ChessSerializable>(stream);

            if (deserializedSave == null)
            {
                throw new ArgumentException("specified save file could not be opened");
            }

            PlayerColor currentPlayer = deserializedSave.CurrentPlayer;

            return (currentPlayer, GetSavedPieces(deserializedSave));
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public async Task<bool> SaveGame(PlayerColor currentPlayer, IChessCell[] board)
        {
            ChessSerializable cs = new()
            {
                CurrentPlayer = currentPlayer,
                Pieces = GetSerializedChessPieces(board)
            };

            FileResult? result = await FilePicker.Default.PickAsync(_filePickerOptions);
            // no save file selected (= saving canceled)
            if (result == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(result.FullPath))
            {
                throw new Exception($"cannot open {result.FullPath}");
            }

            JsonSerializerOptions options = new() { WriteIndented = true };
            using FileStream createStream = File.Create(result.FullPath);
            await JsonSerializer.SerializeAsync(createStream, cs, options);
            await createStream.DisposeAsync();

            return true;
        }

        private IChessPiece GetChessPiece(ChessPieceSerializable cp)
        {
            return cp.Symbol switch
            {
                "B" => new Bishop(cp.Color, cp.Position),
                "KI" => new King(cp.Color, cp.Position),
                "KN" => new Knight(cp.Color, cp.Position),
                "P" => new Pawn(cp.Color, cp.Position),
                "Q" => new Queen(cp.Color, cp.Position),
                "R" => new Rook(cp.Color, cp.Position),
                _ => throw new ArgumentException("the loaded piece contained an unknown symbol"),
            };
        }

        private IList<IChessPiece> GetSavedPieces(ChessSerializable deserializedSave)
        {
            IList<IChessPiece> pieces = new List<IChessPiece>();

            foreach (ChessPieceSerializable cp in deserializedSave.Pieces)
            {
                pieces.Add(GetChessPiece(cp));
            }

            return pieces;
        }

        private IList<ChessPieceSerializable> GetSerializedChessPieces(IChessCell[] board)
        {
            IList<ChessPieceSerializable> pieces = new List<ChessPieceSerializable>();

            foreach (IChessCell c in board)
            {
                if (c.Piece is IChessPiece piece)
                {
                    pieces.Add(new ChessPieceSerializable
                    {
                        Color = piece.Color,
                        Position = piece.CurrentPosition,
                        Symbol = piece.Symbol
                    });
                }
            }

            return pieces;
        }
    }
}