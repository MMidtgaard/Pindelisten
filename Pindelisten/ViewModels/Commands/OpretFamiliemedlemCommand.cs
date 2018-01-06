using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretFamiliemedlemCommand : ICommand
    {
        public PindelisteViewModel ViewModel { get; set; }

        public OpretFamiliemedlemCommand(PindelisteViewModel viewModel)
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
                Familie familie = (Familie)parameter;
                Trace.WriteLine(familie.NytFamilieMedlemNavn);
                if (String.IsNullOrEmpty(familie.NytFamilieMedlemNavn))
                    return false;

                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            Familie familie = (Familie)parameter;
            ViewModel.OpretFamiliemedlem(familie);
        }
    }
}
