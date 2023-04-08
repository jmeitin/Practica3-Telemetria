using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TrackingSystem;

namespace Telemetry
{
    internal class CsvSerializer : ISerializer
    {
        private const string Delimiter = ",";
        private const string LineBreak = "\n";

        public string Serialize(Event e)
        {
            string result = "Type," + e.GetType().Name + ",";

            PropertyInfo[] properties = e.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                result += properties[i].Name + "," + properties[i].GetValue(e) + ",";
            }

            return result.TrimEnd(',');
        }

        public Event Deserialize(string data)
        {
            var splitData = data.Split(new[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var eventType = Type.GetType($"Telemetry.{splitData[1]}");
            var eventInstance = Activator.CreateInstance(eventType);

            for (int i = 2; i < splitData.Length; i += 2)
            {
                var propertyName = splitData[i];
                var propertyValue = splitData[i + 1];
                var property = eventType.GetProperty(propertyName);

                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(eventInstance, int.Parse(propertyValue));
                }
                else if (property.PropertyType == typeof(string))
                {
                    property.SetValue(eventInstance, propertyValue);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    property.SetValue(eventInstance, bool.Parse(propertyValue));
                }
            }

            return (Event)eventInstance;
        }

    }
}
