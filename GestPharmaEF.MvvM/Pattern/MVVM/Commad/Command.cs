using System;
using System.Windows.Input;

namespace GestPharmaEF.Patterns.Mvvm.Commands
{
    public class Command : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add 
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested += value;
            }
            remove 
            {
                if (_canExecute is not null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public Command(Action? execute, Func<bool>? canExecute)
        {
            if(execute is null)
                throw new ArgumentNullException(nameof(execute));
            _execute = execute;

            if (canExecute is null)
                throw new ArgumentNullException(nameof(canExecute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return (_canExecute is null) || _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }
    }
}
