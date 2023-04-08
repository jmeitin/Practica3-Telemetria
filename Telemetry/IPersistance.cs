using Telemetry;

namespace TrackingSystem
{
    internal interface IPersistance
    {
        void Persist(Event e);
    }
}