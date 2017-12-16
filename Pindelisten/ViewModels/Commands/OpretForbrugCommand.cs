using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretForbrugCommand : ICommand
    {
        public PindelisteViewModel ViewModel { get; set; }

        public OpretForbrugCommand(PindelisteViewModel viewModel)
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
            if (parameter != null)
            {
                BeregnetForbrug beregnetForbrug = (BeregnetForbrug)parameter;
                if (beregnetForbrug.Varetype.Lager==0)
                    return false;

                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            BeregnetForbrug beregnetForbrug = (BeregnetForbrug)parameter;
            ViewModel.OpretForbrug(beregnetForbrug.Person, beregnetForbrug.Varetype);
        }
    }
}