using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class VareForbrug
    {
        #region Properties
        /// <summary>
        /// Varetypen
        /// </summary>
        public Pindelistevare Pindelistevare { get; set; }

        /// <summary>
        /// Antal
        /// </summary>
        public int Antal { get; set; }

        /// <summary>
        /// Beregnet forbrug i alt
        /// </summary>
        public decimal BeregnetForbrug { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Construtor der sætter alle værdierne
        /// </summary>
        /// <param name="vare"></param>
        /// <param name="antal"></param>
        /// <param name="beløb"></param>
        public VareForbrug(Pindelistevare vare, int antal, decimal beløb)
        {
            Pindelistevare = vare;
            Antal = antal;
            BeregnetForbrug = beløb;
        }

        #endregion
    }
}
