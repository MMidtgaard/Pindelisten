using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class IndkøbViewModel : BindableBase
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
        /// Holder en valgt familie fra listen
        /// </summary>
        public Familie ValgteFamilie { get; set; }

        /// <summary>
        /// Holder et valgt indkøb fra listen
        /// </summary>
        public Indkøb ValgteIndkøb { get; set; }

        /// <summary>
        /// Navn på nyt indkøb
        /// </summary>
        public string NytIndkøbNavn { get; set; }

        /// <summary>
        /// Pris på nyt indkøb
        /// </summary>
        public decimal NytIndkøbPris { get; set; }

        /// <summary>
        /// Beskrivelse på nyt indkøb
        /// </summary>
        public string NytIndkøbBeskrivelse { get; set; }

        /// <summary>
        /// Holder et valgt Pindelisteindkøb fra listen
        /// </summary>
        public Pindelisteindkøb ValgtePindelisteIndkøb { get; set; }
        
        /// <summary>
        /// Holder en valgt Pindelistevaretype fra listen
        /// </summary>
        public Pindelistevare ValgtePindelistevare { get; set; }

        /// <summary>
        /// Navn på nyt Pindelisteindkøb
        /// </summary>
        public string NytPindelisteIndkøbNavn { get; set; }

        /// <summary>
        /// Pris på nyt Pindelisteindkøb
        /// </summary>
        public decimal NytPindelisteIndkøbPris { get; set; }

        /// <summary>
        /// Beskrivelse på nyt Pindelisteindkøb
        /// </summary>
        public string NytPindelisteIndkøbBeskrivelse { get; set; }

        /// <summary>
        /// Antal varer der er købt i Pindelisteindkøbet
        /// </summary>
        public int NytPindelisteIndkøbAntal { get; set; }


        #endregion

        #region Commands

        /// <summary>
        /// Command til at oprette et indkøb
        /// </summary>
        public OpretIndkøbCommand OpretIndkøbCommand { get; set; }

        /// <summary>
        /// Command til at oprette et indkøb
        /// </summary>
        public OpretPindelisteIndkøbCommand OpretPindelisteIndkøbCommand { get; set; }

        #endregion

        #region Constructor

        public IndkøbViewModel()
        {
            Familier = DataProvider.Familier;
            Pindelistevarer = DataProvider.Pindelistevarer;

            OpretIndkøbCommand = new OpretIndkøbCommand(this);
            OpretPindelisteIndkøbCommand = new OpretPindelisteIndkøbCommand(this);
        }

        #endregion

        #region Metoder


        /// <summary>
        /// Metode der opretter et indkøb, baseret på information der er indtastet i View
        /// </summary>
        /// <param name="familie"></param>
        public void OpretIndkøb(Familie familie)
        {
            if (String.IsNullOrEmpty(NytIndkøbBeskrivelse))
            {
                familie.Indkøb.Add(new Indkøb(NytIndkøbNavn, NytIndkøbPris));
                NytIndkøbNavn = "";
                NytIndkøbPris = 0;
            }
            else
            {
                familie.Indkøb.Add(new Indkøb(NytIndkøbNavn, NytIndkøbBeskrivelse, NytIndkøbPris));
                NytIndkøbNavn = "";
                NytIndkøbPris = 0;
                NytIndkøbBeskrivelse = "";
            }
        }

        /// <summary>
        /// Metode der opretter et Pindelisteindkøb, baseret på information der er indtastet i View
        /// </summary>
        /// <param name="familie"></param>
        public void OpretPindelisteIndkøb(Familie familie)
        {
            NytPindelisteIndkøbNavn = "";
            Pindelisteindkøb nytPindelisteindkøb;

            if (String.IsNullOrEmpty(NytIndkøbBeskrivelse))
            {
                nytPindelisteindkøb = new Pindelisteindkøb(NytPindelisteIndkøbNavn, NytPindelisteIndkøbPris, ValgtePindelistevare, NytPindelisteIndkøbAntal);
            }
            else
            {
                nytPindelisteindkøb = new Pindelisteindkøb(NytPindelisteIndkøbNavn, NytPindelisteIndkøbBeskrivelse, NytPindelisteIndkøbPris, ValgtePindelistevare, NytPindelisteIndkøbAntal);
            }

            familie.Pindelisteindkøb.Add(nytPindelisteindkøb);
            ValgtePindelistevare.TilføjVare(NytPindelisteIndkøbAntal);

            NytPindelisteIndkøbAntal = 0;
            NytPindelisteIndkøbPris = 0;
            ValgtePindelistevare = null;

        }
        #endregion
    }
}
