using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// En udgift som en familie har haft til arrangementet
    /// </summary>
    [Serializable]
    public class Indkøb
    {
        #region Properties

        /// <summary>
        /// Navn på indkøbet
        /// </summary>
        public string Navn { get; set; }

        /// <summary>
        /// Beskrivelse af købet
        /// </summary>
        public string Beskrivelse { get; set; }

        /// <summary>
        /// Tidspunkt for oprettelse af indkøbet i programmet
        /// </summary>
        public DateTime Tidspunkt { get; }

        /// <summary>
        /// Prisen for indkøbet
        /// </summary>
        public decimal Pris { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor uden beskrivelse
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="pris"></param>

        public Indkøb(string navn, decimal pris)
        {
            Navn = navn;
            Pris = pris;
            Tidspunkt = DateTime.Now;
        }

        /// <summary>
        /// Constructor med beskrivelse
        /// </summary>
        /// <param name="navn"></param>
        /// <param name="beskrivelse"></param>
        /// <param name="pris"></param>
        public Indkøb(string navn, string beskrivelse, decimal pris)
        {
            Navn = navn;
            Beskrivelse = beskrivelse;
            Pris = pris;
            Tidspunkt = DateTime.Now;
        }

        #endregion
    }
}
