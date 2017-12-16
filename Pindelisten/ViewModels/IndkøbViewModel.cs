using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    class IndkøbViewModel : BindableBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        /// <summary>
        /// Liste af familier
        /// </summary>
        public ObservableCollection<Familie> Familier { get; set; }

        #endregion

        public IndkøbViewModel()
        {
            //Familier = new ObservableCollection<Familie>();
            Familier = DataProvider.Familier;

        }
    }
}
