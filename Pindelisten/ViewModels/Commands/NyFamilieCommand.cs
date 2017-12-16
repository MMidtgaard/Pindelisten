using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pindelisten
{
    /// <summary>
    /// Command til at tilføje ny familie
    /// </summary>
    public class NyFamilieCommand : ICommand
    {

        public PindelisteViewModel viewModel { get; set; }

        public NyFamilieCommand(PindelisteViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                String s = parameter.ToString();
                if (String.IsNullOrEmpty(s))
                    return false;
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            this.viewModel.OpretFamilie(parameter as String);
        }
    }
}
