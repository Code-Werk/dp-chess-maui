using DP.Chess.MAUI.Features.Chess.Cells;
using DP.Chess.MAUI.Features.Chess.Pieces;
using System.Text.Json;

namespace DP.Chess.MAUI.Features.Chess
{
    public class ChessFileService : IChessFileService
    {
        private const string SAVE_FILE_NAME = "design_patterns_chess.json";

        public async Task<(PlayerColor currentPlayer, IList<IChessPiece> pieces)> LoadGame()
        {
            string path = @"c:\temp\chess\" + SAVE_FILE_NAME;

            if (!File.Exists(path))
            {
                throw new ArgumentException($"save file at path {path} does not exist");
            }

            using FileStream openStream = File.OpenRead(path);
            ChessSerializable deserializedSave =
                await JsonSerializer.DeserializeAsync<ChessSerializable>(openStream);

            PlayerColor currentPlayer = deserializedSave.CurrentPlayer;

            return (currentPlayer, GetSavedPieces(deserializedSave));
        }

        public async Task SaveGame(PlayerColor currentPlayer, IChessCell[] board)
        {
            ChessSerializable cs = new()
            {
                CurrentPlayer = currentPlayer,
                Pieces = GetSerializedChessPieces(board)
            };

            string path = @"c:\temp\chess";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            JsonSerializerOptions options = new() { WriteIndented = true };
            using FileStream createStream = File.Create(path + "\\" + SAVE_FILE_NAME);
            await JsonSerializer.SerializeAsync(createStream, cs, options);
            await createStream.DisposeAsync();
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