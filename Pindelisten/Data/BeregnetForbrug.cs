using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Klasse der holder et beregnet antal af en specifik pindelistevare
    /// </summary>
    [Serializable]
    public class BeregnetForbrug
    {
        #region properties
        /// <summary>
        /// Varen der er beregnet
        /// </summary>
        public Pindelistevare Varetype { get; set; }

        /// <summary>
        /// Hvor mange der er pindelistevaren
        /// </summary>
        public int Antal { get; set; }

        #endregion

        #region constructor
        public BeregnetForbrug(Pindelistevare varetype, int antal)
        {
            Varetype = varetype;
            Antal = antal;
        }

        #endregion
    }
}
