using Telemetry;

namespace TrackingSystem
{
     public interface IPersistance
    {
        void Persist(Event e);
    }
}