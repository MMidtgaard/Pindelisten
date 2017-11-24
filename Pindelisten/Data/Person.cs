using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Person der kan købe varer på pindelisten
    /// </summary>
    [Serializable]
    public class Person
    {
        #region Properties og attributter

        /// <summary>
        /// Personens navn
        /// </summary>
        public String Navn { get; }

        /// <summary>
        /// Liste af forbrug for personen
        /// </summary>
        public ObservableCollection<Forbrug> Forbrug { get; set; }
      
        #endregion


        #region Constructor

        public Person(string navn)
        {
            Navn = navn;
            Forbrug = new ObservableCollection<Forbrug>();
        }

        #endregion

        #region Metoder



        #endregion


    }
}
