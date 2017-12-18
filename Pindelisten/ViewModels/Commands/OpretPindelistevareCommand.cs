using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    public class OpretPindelistevareCommand : ICommand
    {
        public PindelistevaretyperViewModel ViewModel { get; set; }

        public OpretPindelistevareCommand(PindelistevaretyperViewModel viewModel)
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
            if (ViewModel.NyPindelistevareNavn != null || ViewModel.NyPindelistevareNavn == "" && ViewModel.NyPindelistevarePris > 0)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.OpretPindelistevare();

            ViewModel.NyPindelistevareNavn = "";
            ViewModel.NyPindelistevarePris = 0;
        }
    }
}