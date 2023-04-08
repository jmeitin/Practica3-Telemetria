using System;
using Telemetry;

namespace TrackingSystem
{
    internal interface ISerializer
    {
        string Serialize(Event e);
        Event Deserialize(string data);
    }
}