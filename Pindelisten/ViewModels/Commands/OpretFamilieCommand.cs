using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretFamilieCommand : ICommand
    {
        public PindelisteViewModel ViewModel { get; set; }

        public OpretFamilieCommand(PindelisteViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                var s = parameter as String;
                if (String.IsNullOrEmpty(s))
                    return false;

                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.OpretFamilie(parameter as String);
        }
    }
}
