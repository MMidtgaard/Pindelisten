using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class PindelistevaretyperViewModel : BindableBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Liste af pindelistevarer
        /// </summary>
        public ObservableCollection<Pindelistevare> Pindelistevarer { get; set; }

        /// <summary>
        /// Liste af familier
        /// </summary>
        public ObservableCollection<Familie> Familier { get; set; }

        /// <summary>
        /// Property der holder en valgt pindelistevare
        /// </summary>
        public Pindelistevare ValgtePindelistevare { get; set; }

        /// <summary>
        /// Navn på ny pindelistevare
        /// </summary>
        public string NyPindelistevareNavn { get; set; }

        /// <summary>
        /// Navn på ny pindelistevare
        /// </summary>
        public int NyPindelistevarePris { get; set; }

        /// <summary>
        /// Command til at oprette en ny pindelistevare
        /// </summary>
        public OpretPindelistevareCommand OpretPindelistevareCommand { get; set; }

        public PindelistevaretyperViewModel()
        {
            Pindelistevarer = DataProvider.Pindelistevarer;

            Familier = DataProvider.Familier;

            OpretPindelistevareCommand = new OpretPindelistevareCommand(this);
        }

        #region Metoder

        public void OpretPindelistevare()
        {
            Pindelistevarer.Add(new Pindelistevare(NyPindelistevareNavn, NyPindelistevarePris));
            foreach(Familie familie in Familier)
            {
                foreach(Person person in familie.Medlemmer)
                {
                    person.BeregnForbrug(Pindelistevarer);
                }
            }
        }
        #endregion
    }
}