using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows;

namespace Pindelisten
{
    /// <summary>
    /// ViewModel for min pindeliste
    /// </summary>
    public class PindelisteViewModel : BindableBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        /// <summary>
        /// Liste af familier
        /// </summary>
        public ObservableCollection<Familie> Familier { get; set; }

        /// <summary>
        /// Liste af pindelistevarer
        /// </summary>
        public ObservableCollection<Pindelistevare> Pindelistevarer { get; set; }

        /// <summary>
        /// Navnet på en ny familie
        /// </summary>
        public String NyFamilieNavn { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Command til at oprette ny familie
        /// </summary>
        public OpretFamilieCommand OpretFamilieCommand { get; set; }

        /// <summary>
        /// Command til at oprette nyt familiemedlem
        /// </summary>
        public OpretFamiliemedlemCommand OpretFamiliemedlemCommand { get; set; }

        /// <summary>
        /// Command til at oprette et forbrug
        /// </summary>
        public OpretForbrugCommand OpretForbrugCommand { get; set; }

        /// <summary>
        /// Command til at slette et forbrug
        /// </summary>
        public SletForbrugCommand SletForbrugCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor der opretter et objekt af pindelisten
        /// </summary>
        public PindelisteViewModel()
        {
            Familier = DataProvider.Familier;            
            Pindelistevarer = DataProvider.Pindelistevarer;

            OpretFamilieCommand = new OpretFamilieCommand(this);
            OpretFamiliemedlemCommand = new OpretFamiliemedlemCommand(this);
            OpretForbrugCommand = new OpretForbrugCommand(this);
            SletForbrugCommand = new SletForbrugCommand(this);

        }

        #endregion

        #region Metoder

        public void OpretFamilie(String navn)
        {
            bool eksisterer = false;
            if (Familier != null)
            { 
                foreach (Familie familie in Familier)
                {
                    if (familie.Navn == navn)
                        eksisterer = true;
                }
            }
            if (eksisterer == false)
            {
                Familier.Add(new Familie(navn));
                NyFamilieNavn = "";
            }
            else
                MessageBox.Show("Der findes allerede en familie med det navn!", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void OpretForbrug(Person person, Pindelistevare pindelistevare)
        {
            Trace.WriteLine(person.Navn);

            if (pindelistevare.Lager==0)
                MessageBox.Show("Der er ikke flere tilbage af varen!", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Information);

            else
            {
                person.OpretForbrug(pindelistevare);
                pindelistevare.SælgEn();
            }
        }

        public void OpretFamiliemedlem(Familie familie)
        {
            bool eksisterer = familie.OpretFamiliemedlem(Pindelistevarer);
            if (eksisterer == true)
                MessageBox.Show("Der findes allerede et familiemedlem med det navn!", "Fejl!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void SletForbrug(Person person, Pindelistevare pindelistevare)
        {
            person.SletForbrug(pindelistevare);
            pindelistevare.FortrydSalg();
        }

        #endregion
    }
}
