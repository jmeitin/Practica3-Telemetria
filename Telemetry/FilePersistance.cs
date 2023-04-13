using System.IO;
using Telemetry;

namespace TrackingSystem
{
    internal class FilePersistance : PersistanceSystem
    {
        private string path;

        public FilePersistance(string path)
        {
            this.path = path;
        }

        //sobreescribe el meteodo Persist de PersistanceSystem
        protected override void Persist(object data)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(data);
            }
        }
    }
}