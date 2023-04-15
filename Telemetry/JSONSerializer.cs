using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem;

namespace Telemetry
{
    public class JSONSerializer : ISerializer
    {
        public object Serialize(Event e) => JsonConvert.SerializeObject(e, new JsonSerializerSettings
        {
            Formatting = Formatting.None
        });
    }
}
