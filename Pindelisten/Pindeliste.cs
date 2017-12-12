using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Pindelisten
{
    /// <summary>
    /// Hjælpeklasse der henter og gemmer data på fil.
    /// </summary>
    public class Pindeliste
    {
        #region Properties
        /// <summary>
        /// Liste af alle pindelistevarerne
        /// </summary>
        public ObservableCollection<Pindelistevare> Pindelistevarer { get; set; }

        /// <summary>
        /// Liste af alle familierne
        /// </summary>
        public ObservableCollection<Familie> Familier { get; set; }

        #endregion

        #region Attributter
        /// <summary>
        /// Filstier
        /// </summary>

        String familierFil = Environment.CurrentDirectory + "\\Data\\Familier.dat";
        String pindelistevarerFil = Environment.CurrentDirectory + "\\Data\\Pindelistevarer.dat";

        #endregion

        #region Constructor
        public Pindeliste()
        {
            Pindelistevarer = new ObservableCollection<Pindelistevare>();
            Familier = new ObservableCollection<Familie>();

            #region Kode til oprettelse af objekter
            /*
            Pindelistevarer.Add(new Pindelistevare("Øl"));
            Pindelistevarer.Add(new Pindelistevare("Vand"));
            Pindelistevarer.Add(new Pindelistevare("Vin"));


            Familier.Add(new Familie("Midtgaard"));
            Familier.Add(new Familie("Ley"));
            Familier.Add(new Familie("Birkbo"));

            Familier.ElementAt(0).Medlemmer.Add(new Person("Martin"));
            Familier.ElementAt(0).Medlemmer.Add(new Person("Anna"));
            Familier.ElementAt(0).Medlemmer.Add(new Person("Emma"));

            Familier.ElementAt(1).Medlemmer.Add(new Person("Günther"));
            Familier.ElementAt(1).Medlemmer.Add(new Person("Karen"));

            Familier.ElementAt(2).Medlemmer.Add(new Person("Johannes"));
            Familier.ElementAt(2).Medlemmer.Add(new Person("Sophie"));

            Familier.ElementAt(0).Medlemmer.ElementAt(0).Forbrug.Add(new Forbrug(Pindelistevarer.ElementAt(0)));
            
            
            SkrivListerTilFil();*/
            
            #endregion

            HentListerFraFil();

            Familier.ElementAt(0).Medlemmer.ElementAt(0).Forbrug.Add(new Forbrug(Pindelistevarer.ElementAt(0)));

            foreach (Familie familie in Familier)
            {
                foreach (Person person in familie.Medlemmer)
                {
                    person.BeregnForbrug(Pindelistevarer);
                    foreach (BeregnetForbrug forbrug in person.BeregnetForbrug)
                    {
                        Trace.WriteLine(forbrug.Antal.ToString());
                    }
                }
            }

        }
        
        #endregion

        #region Metoder

        /// <summary>
        /// Metode der skriver listerne til fil
        /// </summary>
        public void SkrivListerTilFil()
        {
            BinaryFormatter bf = new BinaryFormatter();

            Stream skrivP = File.OpenWrite(pindelistevarerFil);
            bf.Serialize(skrivP, Pindelistevarer);

            skrivP.Close();

            Stream skrivF = File.OpenWrite(familierFil);
            bf.Serialize(skrivF, Familier);

            skrivF.Close();
        }

        /// <summary>
        /// Metode der henterlisterne fra fil
        /// </summary>
        public void HentListerFraFil()
        {
            BinaryFormatter bf = new BinaryFormatter();

            Stream læsP = File.OpenRead(pindelistevarerFil);
            object vareFraFil = bf.Deserialize(læsP);
            læsP.Close();

            Stream læsF = File.OpenRead(familierFil);
            object familieFraFil = bf.Deserialize(læsF);
            læsF.Close();

            //Caster data fra filerne til listerne
            Familier = (ObservableCollection<Familie>)familieFraFil;
            Pindelistevarer = (ObservableCollection<Pindelistevare>)vareFraFil;
        }

        #endregion
    }
}
