using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingSystem
{
    sealed class Tracker
    {
        // Miembros =======================================================
        Queue<Object> queue;
        private static Tracker? instance;

        // Métodos =========================================================
        private Tracker() { }

        public static Tracker? Instance => instance; // ? no lo devuleve si es null

        public static void Init() // Metodo Instance?
        {
            if (instance != null)
                instance = new Tracker();

            // Init events
        }

        public static void End()
        {
            instance = null;
            // Send end event
        }

        public static bool TrackEvent()
        {
            if (instance == null)
                return false;

            return true;
        }

    }
}