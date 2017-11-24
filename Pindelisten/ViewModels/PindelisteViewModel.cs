using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Pindelisten
{
    /// <summary>
    /// ViewModel for min pindeliste
    /// </summary>
    public class PindelisteViewModel
    {
        #region Properties
        /// <summary>
        /// Liste af familier
        /// </summary>
        public ObservableCollection<Familie> Familier { get; set; }

        /// <summary>
        /// Liste af pindelistevarer
        /// </summary>
        public ObservableCollection<Pindelistevare> Pindelistevarer { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor der opretter et objekt af pindelisten
        /// </summary>
        public PindelisteViewModel()
        {
            ObservableCollection<Familie> Familier = new ObservableCollection<Familie>();
            ObservableCollection<Pindelistevare> Pindelistevarer = new ObservableCollection<Pindelistevare>();
            HentLister();
        }

        #endregion

        #region Metoder

        /// <summary>
        /// Metode der opretter en ny pindeliste og henter listerne til viewet
        /// </summary>
        public void HentLister()
        {
            Pindeliste pindeliste = new Pindeliste();
            Familier = pindeliste.Familier;
            Pindelistevarer = pindeliste.Pindelistevarer;
        }

        #endregion
    }
}
