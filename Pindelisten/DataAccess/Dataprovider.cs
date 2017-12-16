using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Pindelisten
{
    public class DataProvider
    {
        #region Properties

        /// <summary>
        /// Liste af alle pindelistevarerne
        /// </summary>
        public static ObservableCollection<Pindelistevare> Pindelistevarer = new ObservableCollection<Pindelistevare>();

        /// <summary>
        /// Liste af alle familierne
        /// </summary>
        public static ObservableCollection<Familie> Familier = new ObservableCollection<Familie>();

        #endregion

        public void HentFraFil()
        {
            Familier.Add(new Familie("Midtgaard"));
            /*
            String familierFil = Environment.CurrentDirectory + "\\Data\\Familier.dat";
            String pindelistevarerFil = Environment.CurrentDirectory + "\\Data\\Pindelistevarer.dat";

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
            */
        }

        public void GemPåFil()
        {
            String familierFil = Environment.CurrentDirectory + "\\Data\\Familier.dat";
            String pindelistevarerFil = Environment.CurrentDirectory + "\\Data\\Pindelistevarer.dat";
        }

        
    }
}
