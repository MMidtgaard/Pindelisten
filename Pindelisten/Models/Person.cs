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

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="navn"></param>
        public Person(string navn)
        {
            Navn = navn;
            Forbrug = new ObservableCollection<Forbrug>();
            BeregnetForbrug = new ObservableCollection<BeregnetForbrug>();
        }

        /// <summary>
        /// Constructor der samtidig med oprettelsen beregner forbrug baseret på en liste af varer
        /// </summary>
        /// <param name="navn"></param>
        public Person(string navn, ObservableCollection<Pindelistevare> varetyper)
        {
            Navn = navn;
            Forbrug = new ObservableCollection<Forbrug>();
            BeregnetForbrug = new ObservableCollection<BeregnetForbrug>();
            BeregnForbrug(varetyper);
        }

        #endregion

        #region Metoder
        /// <summary>
        /// Modtager en liste af pindelistevaretyper, tæller hvor mange af hver varetype personen har og opdaterer Beregnet forbrug for personen.
        /// </summary>
        /// <param name="varetyper"></param>
        public void BeregnForbrug(ObservableCollection<Pindelistevare> varetyper)
        {
            foreach (Pindelistevare varetype in varetyper)
            {
                int antal = Forbrug.Count(p => p.Varetype.Equals(varetype));

                BeregnetForbrug.Add(new BeregnetForbrug(varetype, antal, this));
            }
        }

        /// <summary>
        /// Privat metode der opdaterer Beregnet forbrug for en enkelt varetype
        /// </summary>
        /// <param name="vareType"></param>
        private void OpdaterBeregnetForbrug(Pindelistevare vareType)
        {
            int antal = Forbrug.Count(p => p.Varetype.Equals(vareType));
            int beregnetForbrugItem = 0;
            
            bool fundet = false;
            while (fundet == false)
            {
                int i = 0;
                if (BeregnetForbrug.ElementAt(i).Varetype.Navn == vareType.Navn)
                {
                    beregnetForbrugItem = i;
                    fundet = true;
                }
                else
                {
                    i++;
                }
            }

            BeregnetForbrug.ElementAt(beregnetForbrugItem).Antal = antal;
        }


        /// <summary>
        /// Opretter et nyt forbrug for personen
        /// </summary>
        /// <param name="varetype"></param>
        public void OpretForbrug(Pindelistevare varetype)
        {
            Forbrug forbrug = new Forbrug(varetype);
            Forbrug.Insert(0, forbrug);

            OpdaterBeregnetForbrug(varetype);
        }

        public void SletForbrug(Pindelistevare varetype)
        {
            Forbrug.Remove(new Forbrug(varetype));

            OpdaterBeregnetForbrug(varetype);
        }

        #endregion

    }
}
