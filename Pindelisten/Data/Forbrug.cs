using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Et forbrug af en vare
    /// </summary>
    [Serializable]
    public class Forbrug
    {
        #region Properties og attributter

        /// <summary>
        /// Tidspunktet for forbruget
        /// </summary>
        public DateTime Tidspunkt { get; }

        /// <summary>
        /// Reference til en varetype
        /// </summary>
        public Pindelistevare Varetype { get; }

        #endregion

        #region Constructor

        public Forbrug(Pindelistevare varetype)
        {
            Varetype = varetype;
            Tidspunkt = DateTime.Now;
        }

        #endregion
    }
}
