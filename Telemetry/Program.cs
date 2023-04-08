using System;
using Telemetry;
using TrackingSystem;

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

