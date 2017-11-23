using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    [Serializable]
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
        public ObservableCollection<Person> Medlemmer { get; set; }

        /// <summary>
        /// Indkøb familien har foretaget
        /// </summary>
        public ObservableCollection<Indkøb> Indkøb { get; set; }

        /// <summary>
        /// Pindeliste indkøb familien har foretaget
        /// </summary>
        public ObservableCollection<Pindelisteindkøb> Pindelisteindkøb { get; set; }

        #endregion

        #region Constructor

        public Familie(string navn)
        {
            Navn = navn;
            Medlemmer = new ObservableCollection<Person>();
            Indkøb = new ObservableCollection<Indkøb>();
            Pindelisteindkøb = new ObservableCollection<Pindelisteindkøb>();
        }

        #endregion
    }
}
