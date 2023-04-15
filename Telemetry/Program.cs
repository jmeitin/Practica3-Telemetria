using System;
using System.IO;
using System.Threading;
using Telemetry;
using TrackingSystem;

// Remove "./logs.txt" file for testing
File.Delete("./logs.txt");

// Inicializar sesión
Tracker.Init();

// Realizar algunas acciones
Tracker.Instance.TrackEvent(new StartGame(1234, 1, 1));
Tracker.Instance.TrackEvent(new TimeStart(1234, 1, 1, 1, 1));
Tracker.Instance.TrackEvent(new TimeReply(1234, 1, 1, 1, 1, true));
Tracker.Instance.TrackEvent(new EndGame(1234, 1, 1));

// Finalizar sesión y persistir eventos
Tracker.End();

Console.WriteLine("Eventos registrados y persistidos con éxito.");