using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Telemetry;

namespace TrackingSystem
{
    sealed class Tracker
    {
        // Miembros =======================================================
        private ConcurrentQueue<Event> queue;
        private static Tracker instance;
        private List<IPersistance> persisters;
        private Thread persistThread;

        // Constructor privado =============================================
        private Tracker()
        {
            queue = new ConcurrentQueue<Event>();
            persisters = new List<IPersistance>();
        }

        // Método Init =====================================================
        public static void Init()
        {
            instance = new Tracker();
            instance.persisters.Add(new FilePersistance("./logs.txt"));
            instance.queue.Enqueue(new StartSession(1, 1));

            //instance.persistThread = new Thread(new ThreadStart(PersistLoop));
            //instance.persistThread.Start();
        }

        // Método End ======================================================
        public static void End()
        {
            instance.queue.Enqueue(new EndSession(1, 1));

            //while (!instance.queue.IsEmpty) { } // Esperar a que la cola se vacíe

            //instance.persistThread.Abort(); // Terminar el hilo persistente
            PersistAllEvents(); // Persistir los eventos restantes
        }

        // Propiedades =====================================================
        public static Tracker Instance => instance;

        // Métodos =========================================================
        public static void Enqueue(Event evnt)
        {
            instance.queue.Enqueue(evnt);
        }

        //private static void PersistLoop()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(5000); // Esperar 5 segundos

        //        PersistAllEvents();
        //    }
        //}

        private static void PersistAllEvents()
        {
            while (instance.queue.TryDequeue(out var evnt))
            {
                foreach (var persister in instance.persisters)
                {
                    persister.Persist(evnt);
                }
            }
        }
    }
}
