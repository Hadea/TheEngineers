using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class Methoden
    {

        /// <summary>
        /// Beispiel für eine einfache Methode
        /// </summary>
        public void DoSomething()
        {
            // nix drin
        }

        public void SomethingWithParameter(string Word, int Number)
        {
            // Die Variablen Word und Number sind gültig solange diese Funktion läuft
        }

        public int SomethingWithParameterAndReturn(string Word)
        {
            return 4; // int wurde angekündigt und muss auch immer geliefert werden
        }


        // Funktionsüberladung (overload) bedeutet das mehrere Methoden den gleichen Namen besitzen und sich
        // nur über ihre Parameter unterscheiden
        public void OverloadedFunction(int Number)
        { }

        public void OverloadedFunction(string Word)
        { }

        public void OverloadedFunction(string Word, int Number)
        { }


        // Rekursion
        // Eine Funktion die sich selbst aufruft
        // Vorsicht, es kann zu endlosschleifen führen oder einem Stackoverflow

        public void RecursiveMethod()
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                RecursiveMethod(); // selbstaufruf. Für den PC ist es ein ganz normaler aufruf einer Funktion
            }
        }

        // Die Methode erhält die Arbeitsspeicheradresse zu einem integer, kann damit kann das original verändert werden
        public static void IncrementByOne(ref int Number)
        {
            Number++;
            Console.WriteLine("Number innerhalb der Methode: " + Number);
        }
        
        // Die Methode erhält die Arbeitsspeicheradresse zu einem integer, veränderungen am original sind nicht erlaubt
        public static void ReadOriginal(in int Number)
        {
            //Number++; //änderungen des originals sind nicht erlaubt
            Console.WriteLine("Number innerhalb der Methode: " + Number); // lesen ist weiter
        }


        // Die Methode erhält die arbeitsspeicheradresse zu einem integer, dieser muss überschrieben werden.
        public static void WriteToOriginal(out int Number)
        {
            Number = 5;
            Console.WriteLine("Number: " + Number);
        }
    }
}