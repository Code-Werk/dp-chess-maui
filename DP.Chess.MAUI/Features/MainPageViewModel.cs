﻿using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DP.Chess.MAUI.Features.ChessBoard;
using DP.Chess.MAUI.Features.ChessBoard.Pieces;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly IMovementService _movementService;

        private ColorSet _currentPlayer;
        private IChessPiece _selectedPiece;

        public MainPageViewModel(IMovementService movementService)
        {
            _movementService = movementService;

            Cells = new CellModel[8 * 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Cells[y * 8 + x] = new CellModel(new Position(x, y));
                }
            }
            CurrentPlayer = ColorSet.White;

            // TODO: ChessBoardFactory
            InitBoard();
        }

        public CellModel[] Cells { get; }

        public ColorSet CurrentPlayer
        {
            get => _currentPlayer;
            set => SetProperty(ref _currentPlayer, value);
        }

        public void InitBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                Cells[8 + x].ChessPiece = new Pawn(ColorSet.Black, Cells[8 + x].Position);
                Cells[6 * 8 + x].ChessPiece = new Pawn(ColorSet.White, Cells[6 * 8 + x].Position);
            }

            Cells[0].ChessPiece = new Rook(ColorSet.Black, Cells[0].Position);
            Cells[7].ChessPiece = new Rook(ColorSet.Black, Cells[7].Position);

            Cells[7 * 8].ChessPiece = new Rook(ColorSet.White, Cells[7 * 8].Position);
            Cells[7 * 8 + 7].ChessPiece = new Rook(ColorSet.White, Cells[7 * 8 + 7].Position);

            Cells[1].ChessPiece = new Knight(ColorSet.Black, Cells[1].Position);
            Cells[6].ChessPiece = new Knight(ColorSet.Black, Cells[6].Position);

            Cells[7 * 8 + 1].ChessPiece = new Knight(ColorSet.White, Cells[7 * 8 + 1].Position);
            Cells[7 * 8 + 6].ChessPiece = new Knight(ColorSet.White, Cells[7 * 8 + 6].Position);

            Cells[2].ChessPiece = new Bishop(ColorSet.Black, Cells[2].Position);
            Cells[5].ChessPiece = new Bishop(ColorSet.Black, Cells[5].Position);

            Cells[7 * 8 + 2].ChessPiece = new Bishop(ColorSet.White, Cells[7 * 8 + 2].Position);
            Cells[7 * 8 + 5].ChessPiece = new Bishop(ColorSet.White, Cells[7 * 8 + 5].Position);

            Cells[3].ChessPiece = new King(ColorSet.Black, Cells[3].Position);
            Cells[7 * 8 + 3].ChessPiece = new King(ColorSet.White, Cells[7 * 8 + 3].Position);

            Cells[4].ChessPiece = new Queen(ColorSet.Black, Cells[4].Position);
            Cells[7 * 8 + 4].ChessPiece = new Queen(ColorSet.White, Cells[7 * 8 + 4].Position);
        }

        private void RemoveCellSelection()
        {
            foreach (CellModel cell in Cells)
            {
                cell.IsSelected = false;
            }
        }

        #region ChessMoveCommand

        private ICommand _chessMoveCommand;

        /// <summary>
        /// Gets the command that is executed to make a chess move (Schachzug)
        /// in the game. A complete chess turn executes this command twice, once
        /// to select the piece that should be moved, and a second time to move
        /// the piece to the desired position. The move may contain taking an
        /// opponent piece or not.
        /// </summary>
        public ICommand ChessMoveCommand => _chessMoveCommand
            ??= new RelayCommand<CellModel>(DoChessMove);

        private void DoChessMove(CellModel cell)
        {
            if (_selectedPiece == null
                && (cell.ChessPiece == null || cell.ChessPiece.Color != CurrentPlayer))
            {
                RemoveCellSelection();
                return;
            }

            // chess piece to move was selected for the first time this move
            if (_selectedPiece == null)
            {
                _selectedPiece = cell.ChessPiece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            // player clicked on another piece of the same color
            if (_selectedPiece.Color == cell.ChessPiece?.Color)
            {
                _selectedPiece = cell.ChessPiece;
                RemoveCellSelection();
                cell.IsSelected = true;
                return;
            }

            try
            {
                if (!_movementService.CanMove(Cells, _selectedPiece, cell))
                {
                    IToast toast = Toast.Make("Invalid move.", ToastDuration.Short);
                    toast.Show();
                    return;
                }

                // an empty field or one occupied by an opponent was selected
                _movementService.Move(_selectedPiece, Cells[_selectedPiece.CurrentPosition.ToBoardIndex()], cell);
                CurrentPlayer = CurrentPlayer == ColorSet.White
                    ? ColorSet.Black
                    : ColorSet.White;
            }
            finally
            {
                // reset the selected piece for the next move
                RemoveCellSelection();
                _selectedPiece = null;
            }
        }

        #endregion ChessMoveCommand

        #region LoadCommand

        private ICommand _loadCommand;

        public ICommand LoadCommand => _loadCommand
            ??= new AsyncRelayCommand(LoadGame);

        private async Task LoadGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion LoadCommand

        #region UndoCommand

        private ICommand _undoCommand;

        public ICommand UndoCommand => _undoCommand
            ??= new RelayCommand(UndoMove);

        private void UndoMove()
        {
            throw new NotImplementedException();
        }

        #endregion UndoCommand

        #region RedoCommand

        private ICommand _redoCommand;

        public ICommand RedoCommand => _redoCommand
            ??= new RelayCommand(RedoMove);

        private void RedoMove()
        {
            throw new NotImplementedException();
        }

        #endregion RedoCommand

        #region SaveCommand

        private ICommand _saveCommand;

        public ICommand SaveCommand => _saveCommand
            ??= new AsyncRelayCommand(SaveGame);

        private async Task SaveGame()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        #endregion SaveCommand
    }
}