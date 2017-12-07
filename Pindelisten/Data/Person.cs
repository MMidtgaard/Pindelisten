using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Person der kan købe varer på pindelisten
    /// </summary>
    [Serializable]
    public class Person
    {
        #region Properties og attributter

        /// <summary>
        /// Personens navn
        /// </summary>
        public String Navn { get; }

        /// <summary>
        /// Liste af forbrug for personen
        /// </summary>
        public ObservableCollection<Forbrug> Forbrug { get; set; }

        /// <summary>
        /// Personens forbrug beregnet og fordelt på varetyper. Indeholder også en 0-angivelse af varetyper der ikke er købt.
        /// </summary>
        public ObservableCollection<BeregnetForbrug> BeregnetForbrug { get; }
      
        #endregion

        #region Constructor

        public Person(string navn)
        {
            Navn = navn;
            Forbrug = new ObservableCollection<Forbrug>();
            BeregnetForbrug = new ObservableCollection<BeregnetForbrug>();
        }

        #endregion

        #region Metoder
        /// <summary>
        /// Modtager en liste af pindelistevaretyper, tæller hvor mange af hver varetype personen har og opdaterer Beregnet forbrug for personen.
        /// </summary>
        /// <param name="varetyper"></param>
        public void BeregnForbrug(ObservableCollection<Pindelistevare> varetyper)
        {
            foreach(Pindelistevare varetype in varetyper)
            {
                int antal = Forbrug.Count(p => p.Varetype.Equals(varetype));

                BeregnetForbrug.Add(new BeregnetForbrug(varetype, antal));
            }
        }

        #endregion

    }
}
