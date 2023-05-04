using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    public class Command : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Func<Task> execute, Func<bool> canExecute)
        {
            _canExecute= canExecute;
            _execute= execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public async void Execute(object parameter)
        {
            await _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
