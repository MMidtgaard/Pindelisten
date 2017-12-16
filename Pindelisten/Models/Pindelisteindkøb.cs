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

        public Pindelisteindkøb(String navn, Pindelistevare varetype, int Antal) : base(navn)
        {
            Navn = navn;
        }

        public Pindelisteindkøb(String navn, String beskrivelse, Pindelistevare varetype, int Antal) : base(navn, beskrivelse)
        {
            Navn = navn;
            Beskrivelse = beskrivelse;
        }
        #endregion
    }
}
