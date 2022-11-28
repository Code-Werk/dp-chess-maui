using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using DP.Chess.MAUI.Features.Chess.Boards;
using DP.Chess.MAUI.Features.Chess.GameState;
using DP.Chess.MAUI.Infrastructure.Memento;
using DP.Chess.MAUI.Resources.I18N;

namespace DP.Chess.MAUI.Features.Chess
{
    /// <summary>
    /// Service containing state logic specific for a game of chess.
    /// </summary>
    public class ChessGameStateService : IChessGameStateService
    {
        private readonly IMementoPersistCaretaker<ChessMemento> _mementoPersistCaretaker;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ChessGameStateService" /> class.
        /// </summary>
        /// <param name="mementoPersistCaretaker">
        /// The service that takes care of the memento instances.
        /// </param>
        public ChessGameStateService(IMementoPersistCaretaker<ChessMemento> mementoPersistCaretaker)
        {
            _mementoPersistCaretaker = mementoPersistCaretaker;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public async Task LoadGame(IChessBoard board)
        {
            bool isCanceled = false;
            IToast toast = Toast.Make(AppResources.General_GameLoaded_Success, ToastDuration.Long);

            try
            {
                await _mementoPersistCaretaker.LoadMementos();
                board.RestoreMemento(_mementoPersistCaretaker.Current);
            }
            catch (Exception)
            {
                // overwrite the toast in case of an exception
                toast = Toast.Make(AppResources.General_GameLoaded_Error, ToastDuration.Long);
            }
            finally
            {
                if (!isCanceled)
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public async Task RedoMovement(IChessBoard board)
        {
            ChessMemento? memento = _mementoPersistCaretaker.Redo();

            if (memento is null)
            {
                await Toast.Make(AppResources.General_GameRedo_Error, ToastDuration.Short).Show();
                return;
            }

            board.RestoreMemento(memento);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public async Task SaveGame(IChessBoard board)
        {
            bool isCanceled = false;
            IToast toast = Toast.Make(AppResources.General_GameSaved_Success, ToastDuration.Long);

            try
            {
                ChessMemento memento = board.SaveMemento();
                isCanceled = !await _mementoPersistCaretaker.SaveMementos();
            }
            catch (Exception)
            {
                // overwrite the toast in case of an exception
                toast = Toast.Make(AppResources.General_GameSaved_Error, ToastDuration.Long);
            }
            finally
            {
                if (!isCanceled)
                {
                    CancellationTokenSource cancellationTokenSource = new();
                    await toast.Show(cancellationTokenSource.Token);
                }
            }
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <param name="board"><inheritdoc /></param>
        /// <returns><inheritdoc /></returns>
        public async Task UndoMovement(IChessBoard board)
        {
            ChessMemento? memento = _mementoPersistCaretaker.Undo();

            if (memento is null)
            {
                await Toast.Make(AppResources.General_GameUndo_Error, ToastDuration.Short).Show();
                return;
            }

            board.RestoreMemento(memento);
        }
    }
}