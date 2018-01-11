using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class RapportViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// Liste af Familieforbrug
        /// </summary>
        public List<Familierapport> Familierapporter { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Simpel constructor der kalder metoden til at danne listen.
        /// </summary>
        public RapportViewModel()
        {
            Familierapporter = new List<Familierapport>();
            danRapport();
        }

        #endregion

        #region Metoder

        /// <summary>
        /// Metoden danner nye objekter af typen FamilieForbrug og tilføjer dem til listen. Bemærk at der benyttes de to static lister fra Dataprovideren.
        /// </summary>
        private void danRapport()
        {
            var varerList = new List<Pindelistevare>(DataProvider.Pindelistevarer);
            foreach (Familie familie in DataProvider.Familier)
            {
                Familierapporter.Add(new Familierapport(familie, varerList));
            }
        }
        #endregion
    }
}
