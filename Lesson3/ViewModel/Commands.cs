using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lesson3.ViewModel
{
    class Command_Button : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if ()
            return true;gj nhtnmtve pflfyb.
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
