using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem;

namespace Telemetry
{
    internal abstract class PersistanceSystem : IPersistance
    {
        private readonly ISerializer serializer;

        protected PersistanceSystem()
        {
            serializer = new CsvSerializer();
        }

        protected abstract void Persist(object data);

        public void Persist(Event e)
        {
            Persist(serializer.Serialize(e));
        }
    }
}

