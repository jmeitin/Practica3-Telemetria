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

        // Object dado que puede ser csv o json
        protected abstract void Persist(object data);

        public void Persist(Event e)
        {
            Persist(serializer.Serialize(e));
        }
    }
}

