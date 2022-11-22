namespace DP.Chess.MAUI.Features.ChessBoard.Pieces
{
    public class Rook : ChessPiece, IChessPiece
    {
        public Rook(ColorSet color, Position currentPosition)
            : base(color, currentPosition, "R")
        {
        }

        public override bool CheckTargetPosition(CellModel[] board, CellModel targetCell)
        {
            throw new NotImplementedException();
        }

        public override void UpdatePossibleMoveSet()
        {
            IList<Position> moveSet = new List<Position>();

            for (int i = 0; i < 8; i++)
            {
                Position px = new(CurrentPosition.X, i);
                Position py = new(i, CurrentPosition.Y);

                if (px != CurrentPosition)
                {
                    moveSet.Add(px);
                }
                if (py != CurrentPosition)
                {
                    moveSet.Add(py);
                }
            }

            PossibleMoveSet = moveSet.ToArray();
        }
    }
}