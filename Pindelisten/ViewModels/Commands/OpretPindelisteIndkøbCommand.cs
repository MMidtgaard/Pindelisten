using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretPindelisteIndkøbCommand : ICommand
    {
        public IndkøbViewModel ViewModel { get; set; }

        public OpretPindelisteIndkøbCommand(IndkøbViewModel viewModel)
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
            if (ViewModel.ValgteFamilie != null && ViewModel.ValgtePindelistevare != null && ViewModel.NytPindelisteIndkøbAntal > 0 && ViewModel.NytPindelisteIndkøbPris > 0)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            Familie familie = (Familie)parameter;
            ViewModel.OpretPindelisteIndkøb(familie);
        }
    }
}
