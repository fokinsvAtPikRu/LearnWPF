using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lesson8.Presentation.Commands
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<object?,Task> _execute;
        private readonly Func<object?,bool> _canExecuted;
        private bool _isExecuting;
        
        public event EventHandler? CanExecuteChanged;

        public AsyncRelayCommand(Func<object?,Task> execute, Func<object?, bool> canExecuted = null)
        {
            _execute = execute;
            _canExecuted = canExecuted;
        }
        public bool CanExecute(object? parameter)
        {
            return !_isExecuting && (_canExecuted?.Invoke(parameter) ?? true);
        }

        public async void Execute(object? parameter)
        {
            if (_isExecuting) return;

            _isExecuting = true;
            RaiseCanExecuteChanged();

            try
            {
                await _execute(parameter);
            }
            finally
            {
                _isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}
