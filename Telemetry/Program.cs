using System;
using System.IO;
using System.Threading;
using Telemetry;
using Telemetry.PersistanceSystem;
using Telemetry.SerializationSystem;
using TrackingSystem;

// Remove "./logs.txt" file for testing
File.Delete("./logs.csv");
File.Delete("./logs.json");

// Inicializar sesión
Tracker.Init("Fede");

// Realizar algunas acciones
Tracker.Instance.AddPersistanceSystem(new FilePersistance(new CsvSerializer(), "./logs.csv"));
Tracker.Instance.TrackEvent(new StartGame());
Tracker.Instance.TrackEvent(new TimeStart(1, 2));
Tracker.Instance.TrackEvent(new TimeReply(1, 1, true));
Tracker.Instance.TrackEvent(new EndGame());

// Finalizar sesión y persistir eventos
Tracker.End();

Console.WriteLine("Eventos registrados y persistidos con éxito.");