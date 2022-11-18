using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace DP.Chess.MAUI.Features
{
    public class MainPageViewModel : ObservableObject
    {
        private int _counter;

        public int Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
        }

        #region IncreaseCounterCommand

        private ICommand _increaseCounterCommand;

        public ICommand IncreaseCounterCommand => _increaseCounterCommand ??= new RelayCommand(IncreaseCounter);

        private void IncreaseCounter()
        {
            Counter++;
        }

        #endregion IncreaseCounterCommand
    }
}