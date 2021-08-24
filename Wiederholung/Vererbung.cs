using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class Vererbung
    {
        public static void DoSomething()
        {
            Delorean d = new();

            d.OpenDoor();
            d.Fenster = 5;

            Auto[] Stau = new Auto[5];
            Stau[0] = new Ferrari();
            Stau[1] = new Delorean();
            Stau[2] = new Delorean();
            Stau[3] = new Audi();
            Stau[4] = new TimeMashine();

            for (int counter = 0; counter < Stau.Length; counter++)
            {
                Stau[counter].OpenDoor();
            }
            /* alternativ geht auch der foreach-loop
            foreach (var item in Stau)
            {
                item.OpenDoor();
            }
            */
            for (int counter = 0; counter < Stau.Length; counter++)
            {
                Stau[counter].CloseDoor();
            }

            IBlueToothAudio audio = new AutoRadio();

        }
    }

    interface IBlueToothAudio
    {
        public void Play();
        public void Stop();
    }

    class AutoRadio : IBlueToothAudio , IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }


    abstract class Auto // abstract bedeutet das kein objekt vom typ auto erstellt werden kann und dies eher als bauplan angesehen wird
    {
        private int Zylinder; // nur für die eigene klasse. Wird nicht vererbt.
        protected int Raeder; // "Fammiliengeheimnis" Wie private, wird aber vererbt.
        internal int Sitze; // Wie public, aber nur für die gleiche Assembly
        public int Fenster; // Hier kommt jeder ran. Wird auch vererbt.
        public virtual void OpenDoor()
        {
            Zylinder = 5;
            Console.WriteLine("Die Tür wird nach vorn geöffnet");
        }

        public abstract void CloseDoor(); // Erbende Klassen müssen alle abstrakten methoden implementieren
    }

    class Ferrari : Auto
    {
        public override void CloseDoor()
        {
            Console.WriteLine("Ferrari schliesst die tür");
        }

        public void TestMethod()
        {
            Fenster = 5;
            Raeder = 5;
            // kein zugriff auf Zylinder
        }
    }

    class Delorean : Auto
    {
        public override void OpenDoor()
        {
            Console.WriteLine("Tür wird nach oben geöffnet");
        }

        public override void CloseDoor()
        {
            Console.WriteLine("Delorean Tür zu");
        }
    }

    class Audi : Auto
    {
        public sealed override void CloseDoor() // sealed auf methoden verhindert das bei einer vererbund diese methode mit override ersetzt wird
        {
            Console.WriteLine("Audi Tür wird geschlossen");
        }
    }

    sealed class TimeMashine : Delorean // sealed verhindert weitere vererbungen
    {
        public override void OpenDoor()
        {
            Console.WriteLine("Tür wird nach oben geöffnet bei der Zeitmaschine");
        }
    }
}
