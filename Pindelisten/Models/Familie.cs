using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    [Serializable]
    public class Familie : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        /// <summary>
        /// Holder midlertidigt navn på nyt familiemedlem
        /// </summary>
        public String NytFamilieMedlemNavn { get; set; }

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

        #region Metoder

        /// <summary>
        /// Metode til at oprette nyt familiemedlem
        /// </summary>
        public bool OpretFamiliemedlem(ObservableCollection<Pindelistevare> varetyper)
        {
            bool eksisterer = false;
            foreach (Person person in Medlemmer)
            {
                if (person.Navn == NytFamilieMedlemNavn)
                    eksisterer = true;
            }
            if (eksisterer == false)
            {
                Medlemmer.Add(new Person(NytFamilieMedlemNavn, varetyper));
                NytFamilieMedlemNavn = null;
            }

            return eksisterer;
        }
        #endregion
    }
}
