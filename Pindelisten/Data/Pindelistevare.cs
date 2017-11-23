using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// En vare som kan købes på pindelisten.
    /// </summary>
    [Serializable]
    public class Pindelistevare
    {
        #region Properties
        
        /// <summary>
        /// Navnet på varen
        /// </summary>
        public String Navn { get; set; }

        /// <summary>
        /// Prisen på varen
        /// </summary>
        public decimal Pris { get; set; }

        /// <summary>
        /// Hvor mange der er af varen på lager
        /// </summary>
        public int Lager { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Opretter en vare med et navn
        /// </summary>
        public Pindelistevare(string navn)
        {
            Navn = navn;
        }

        #endregion

        #region Metoder

        /// <summary>
        /// Tilføjer givet antal varer til lager
        /// </summary>
        /// <param name="antal"></param>
        public void TilføjVare(int antal)
        {
            Lager = Lager + antal;
        }

        /// <summary>
        /// Fjerner en vare fra lageret
        /// </summary>
        public void SælgEn()
        {
            Lager--;
        }

        /// <summary>
        /// Tilføjer en vare til lageret
        /// </summary>
        public void FortrydSalg()
        {
            Lager++;
        }

        #endregion
    }
}