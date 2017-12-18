using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Et indkøb foretaget af en familie af en specifik vare der kan købes på pindelisten.
    /// </summary>
    [Serializable]
    public class Pindelisteindkøb : Indkøb
    {
        #region Properties
        
        /// <summary>
        /// Typen af pindelistevare
        /// </summary>
        public Pindelistevare Varetype { get; }

        /// <summary>
        /// Antal der er købt
        /// </summary>
        public int Antal { get; }

        #endregion

        #region Constructor

        public Pindelisteindkøb(string navn, decimal pris, Pindelistevare varetype, int antal) : base(navn, pris)
        {
            Varetype = varetype;
            Antal = antal;
        }

        public Pindelisteindkøb(string navn, string beskrivelse, decimal pris, Pindelistevare varetype, int antal) : base(navn, beskrivelse, pris)
        {
            Varetype = varetype;
            Antal = antal;
        }
        #endregion
    }
}
