using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    /// <summary>
    /// Klasse der holder et beregnet antal af en specifik pindelistevare
    /// </summary>
    [Serializable]
    public class BeregnetForbrug : IEquatable<Pindelistevare>, INotifyPropertyChanged
    {
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        #region properties
        /// <summary>
        /// Varen der er beregnet
        /// </summary>
        public Pindelistevare Varetype { get; set; }

        /// <summary>
        /// Hvor mange der er pindelistevaren
        /// </summary>
        public int Antal { get; set; }

        /// <summary>
        /// Personen det beregnede forbrug tilhører
        /// </summary>
        public Person Person { get; set; }

        #endregion

        #region constructor
        public BeregnetForbrug(Pindelistevare varetype, int antal, Person person)
        {
            Varetype = varetype;
            Antal = antal;
            Person = person;
        }

        #endregion

        #region Metoder

        public bool Equals(Pindelistevare other)
        {
            if (other == null) return false;
            return (this.Varetype.Equals(other));
        }

        #endregion 
    }
}
