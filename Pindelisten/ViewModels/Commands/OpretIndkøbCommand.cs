using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretIndkøbCommand : ICommand
    {
        public IndkøbViewModel ViewModel { get; set; }

        public OpretIndkøbCommand(IndkøbViewModel viewModel)
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
            bool tom = String.IsNullOrEmpty(ViewModel.NytIndkøbNavn);
            if (ViewModel.ValgteFamilie != null && ViewModel.NytIndkøbPris > 0 && tom==false)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Familie familie = (Familie)parameter;
            ViewModel.OpretIndkøb(familie);
        }
    }
}
