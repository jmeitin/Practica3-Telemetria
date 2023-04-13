using System;
using System.IO;
using Telemetry;
using TrackingSystem;

// Remove "./logs.txt" file for testing
File.Delete("./logs.txt");

// Inicializar sesión
Tracker.Init();

// Realizar algunas acciones
Tracker.TrackEvent(new StartGame(1234, 1, 1));
Tracker.TrackEvent(new TimeStart(1234, 1, 1, 1, 1));
Tracker.TrackEvent(new TimeReply(1234, 1, 1, 1, 1, true));
Tracker.TrackEvent(new EndGame(1234, 1, 1));

// Finalizar sesión y persistir eventos
Tracker.End();

Console.WriteLine("Eventos registrados y persistidos con éxito.");

CsvSerializer serializer= new CsvSerializer();
StreamReader sr = File.OpenText("./logs.txt");
string s = sr.ReadLine();
Event e = serializer.Deserialize(s);
Console.WriteLine(e.ToString());
Console.WriteLine(e.id_session);
Console.WriteLine("Evento deserializado con éxito.");