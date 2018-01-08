using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        private string familierFil = Environment.CurrentDirectory + "\\Familier.dat";
        private string pindelistevarerFil = Environment.CurrentDirectory + "\\Pindelistevarer.dat";

        #endregion

        public DataProvider()
        {

        }

        public bool HentFraFil()
        {
            Trace.WriteLine("Test");
            if (File.Exists(familierFil) && File.Exists(pindelistevarerFil))
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

                return true;
            }

            else
            {
                return false;
            }
            
        }

        public void GemPåFil()
        {
            Trace.WriteLine("her");
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(familierFil))
            {
                File.Delete(familierFil);
            }
            FileStream fs = File.Create(familierFil);
            bf.Serialize(fs, Familier);
            fs.Close();

            if (File.Exists(pindelistevarerFil))
            {
                File.Delete(pindelistevarerFil);

            }
            fs = File.Create(pindelistevarerFil);
            bf.Serialize(fs, Pindelistevarer);
            fs.Close();
        }        
    }
}
