using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{

    public class MainWindowViewModel : BindableBase
    {
        public DataProvider dataProvider = new DataProvider();

        private PindelisteViewModel pindelisteViewModel = new PindelisteViewModel();

        private IndkøbViewModel indkøbViewModel = new IndkøbViewModel();

        private PindelistevaretyperViewModel pindelistevaretyperViewModel = new PindelistevaretyperViewModel();

        private BindableBase _CurrentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { SetProperty(ref _CurrentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }

        public HentDataCommand HentDataCommand { get; set; }

        public GemDataCommand GemDataCommand { get; set; }

        public MainWindowViewModel()
        {
            HentDataCommand = new HentDataCommand(this);
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = pindelisteViewModel;
        }

        public void HentData()
        {
           dataProvider.HentFraFil();
        }

        public void GemData()
        {
            dataProvider.GemPåFil();
        }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "Pindeliste":
                    CurrentViewModel = pindelisteViewModel;
                    break;
                case "Indkøb":
                    CurrentViewModel = indkøbViewModel;
                    break;
                case "Pindelistevarer":
                    CurrentViewModel = pindelistevaretyperViewModel;
                    break;
            }
        }
    }
}