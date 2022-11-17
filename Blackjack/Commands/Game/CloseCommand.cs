using System;
using System.Windows.Input;

namespace Blackjack.Commands.Game
{
    public class CloseCommand : ICommand
    {
        public CloseCommand()
        {

        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            App.Current.MainWindow.Close();
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
