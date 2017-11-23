using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class Familie
    {
        #region Properties

        /// <summary>
        /// Navnet på familien
        /// </summary>
        public String Navn { get; }
        
        /// <summary>
        /// Medlemmerne af familien
        /// </summary>
        public List<Person> Medlemmer{ get; set; }

        /// <summary>
        /// Indkøb familien har foretaget
        /// </summary>
        public List<Indkøb> Indkøb { get; set; }

        /// <summary>
        /// Pindeliste indkøb familien har foretaget
        /// </summary>
        public List<Pindelisteindkøb> Pindelisteindkøb { get; set; }

        #endregion

        #region Constructor

        public Familie(string navn)
        {
            Navn = navn;
        }

        #endregion
    }
}
