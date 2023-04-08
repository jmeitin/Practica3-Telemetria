using System;
using System.IO;
using Telemetry;
using TrackingSystem;

// Remove "./logs.txt" file for testing
File.Delete("./logs.txt");

// Inicializar sesión
Tracker.Init();

// Realizar algunas acciones
Tracker.Enqueue(new StartGame(1234, 1, 1));
Tracker.Enqueue(new TimeStart(1234, 1, 1, 1, 1));
Tracker.Enqueue(new TimeReply(1234, 1, 1, 1, 1, true));
Tracker.Enqueue(new EndGame(1234, 1, 1));

// Finalizar sesión y persistir eventos
Tracker.End();

Console.WriteLine("Eventos registrados y persistidos con éxito.");

