using System;
using Telemetry;

namespace TrackingSystem
{
    internal interface ISerializer
    {
        object Serialize(Event e);
        //Event Deserialize(string data);
    }
}