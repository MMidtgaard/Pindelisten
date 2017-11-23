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
    public class Indkøb
    {
        #region Properties

        /// <summary>
        /// Navn på indkøbet
        /// </summary>
        public String Navn { get; set; }

        /// <summary>
        /// Beskrivelse af købet
        /// </summary>
        public String Beskrivelse { get; set; }

        /// <summary>
        /// Tidspunkt for oprettelse af indkøbet i programmet
        /// </summary>
        public DateTime Tidspunkt { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor uden beskrivelse
        /// </summary>
        /// <param name="navn"></param>

        public Indkøb(String navn)
        {
            Navn = navn;
            Tidspunkt = DateTime.Now;
        }

        public Indkøb(String navn, String beskrivelse)
        {
            Navn = navn;
            Beskrivelse = beskrivelse;
            Tidspunkt = DateTime.Now;
        }

        #endregion
    }
}
