using System;

namespace Wiederholung
{
    class UsingDemo
    {
        public static void DoSomething()
        {
            using (RessourcenKlasse resource = new())
            {

                // operationen auf der Ressource
                // operationen auf der Ressource
                // operationen auf der Ressource
                // operationen auf der Ressource
            }

            //resource.Close();
            //resource.Dispose();
        }
    }

    class RessourcenKlasse : IDisposable
    {
        bool ressourcenBereitsFreigegeben;

        public RessourcenKlasse()
        {
            Console.WriteLine("Reserviere die Ressourcen");
            // reserviert die ressourcen
            // z.B. baut eine Netzwerkverbindung auf
        }

        public void Close()
        {
            if (ressourcenBereitsFreigegeben)
                return;
            Console.WriteLine("Gebe die Ressourcen frei");
            ressourcenBereitsFreigegeben = true;
            // gibt die ressourcen wieder frei
            // z.B. trennt eine Netzwerkverbindung
        }

        public void Dispose() // wird vom using aufgerufen sobald die Klammern verlassen werden
        {
            Console.WriteLine("es gibt keine ressourcen");
            Close();
        }
    }
}
