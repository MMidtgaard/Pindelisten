using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class Familierapport
    {
        #region Properties

        /// <summary>
        /// Familien
        /// </summary>
        public Familie Familie { get; set; }

        /// <summary>
        /// Familiens forbrug af en enkelt vare
        /// </summary>
        public List<VareForbrug> Forbrug { get; set; }

        /// <summary>
        /// Familiens totale udlæg
        /// </summary>
        public decimal UdlægTotal { get; set; }

        /// <summary>
        /// Familiens Saldo
        /// </summary>
        public decimal ForbrugTotal { get; set; }

        /// <summary>
        /// Familiens Saldo
        /// </summary>
        public decimal Saldo { get; set; }

        #endregion

        #region constructor
        /// <summary>
        /// Constructor der sætter familien og den pågældende vare, den kalder også metoden der beregner tæller sammen og beregner forbruget, udlæg og saldo for hele familien.
        /// </summary>
        /// <param name="familie"></param>
        public Familierapport(Familie familie, List<Pindelistevare> varer)
        {
            Familie = familie;
            Forbrug = new List<VareForbrug>();
            BeregnForbrug(varer);
            BeregnUdlæg();
            BeregnForbrugTotal();
            BeregnSaldo();
        }
        #endregion

        #region metoder

        /// <summary>
        /// Metode der beregner forbruget for familien pr. varetype
        /// </summary>
        private void BeregnForbrug(List<Pindelistevare> varer)
        {
            foreach (Pindelistevare vare in varer)
            {
                int antalSum = 0;
                foreach (Person medlem in Familie.Medlemmer)
                {
                    int antal = medlem.Forbrug.Count(p => p.Varetype.Equals(vare));
                    antalSum = antalSum + antal;
                }
                decimal forbrugBeløbSum = antalSum * vare.Pris;
                Forbrug.Add(new VareForbrug(vare, antalSum, forbrugBeløbSum));
            }
        }

        /// <summary>
        /// Metode der tæller det totale udlæg for familien sammen
        /// </summary>
        private void BeregnUdlæg()
        {
            foreach(Indkøb indkøb in Familie.Indkøb)
            {
                UdlægTotal = UdlægTotal + indkøb.Pris;
            }

            foreach(Pindelisteindkøb pindkøb in Familie.Pindelisteindkøb)
            {
                UdlægTotal = UdlægTotal + pindkøb.Pris;
            }
        }

        /// <summary>
        /// Metode der tæller det totale forbrug for alle varer for hele familien sammen
        /// </summary>
        private void BeregnForbrugTotal()
        {
            foreach (VareForbrug forbrug in Forbrug)
            {
                ForbrugTotal = ForbrugTotal + forbrug.BeregnetForbrug;
            }
        }

        /// <summary>
        /// Metode der beregner saldoen for familien
        /// </summary>
        private void BeregnSaldo()
        {
            Saldo = UdlægTotal - ForbrugTotal;
        }
        #endregion
    }
}
