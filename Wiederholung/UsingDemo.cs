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

            } //resource.Close();
        }
    }

    class RessourcenKlasse : IDisposable
    {
        public RessourcenKlasse()
        {
            // reserviert die ressourcen
        }

        public void Close()
        {
            // gibt die ressourcen wieder frei
        }

        public void Dispose() // wird vom using aufgerufen sobald die Klammern verlassen werden
        {
            Close();
        }
    }


}
