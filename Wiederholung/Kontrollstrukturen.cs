using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class Kontrollstrukturen
    {
        void DoSomething()
        {
            // Bedingungen

            if (Environment.ProcessorCount / 7 < 2)
            {
                //wenn innerhalb der if-Klammern true ausgerechnet wird
            }

            if (4>2)
            {
                // wenn bedinung als true ausgerechnet wird
            }
            else
            {
                // wenn bedingung als false ausgerechnet wird
            }

            //             test ? true : false
            string ausgabe = (DateTime.Now.Day % 2 == 0 ? "Tag ist gerade" : "Tag ist ungerade");

            if (ausgabe == "Tag ist gerade") return;

            Automarke auto = Automarke.BMW;

            switch (auto)
            {
                case Automarke.BMW:
                    Console.WriteLine(@"BMW wurde gefunden");
                    break;
                case Automarke.Audi:
                    Console.WriteLine(@"Audi gefunden");
                    break;
                default:
                    Console.WriteLine(@"etwas anderes wurde gefunden");
                    break;
            }

            var HerstellerNummer = auto switch
            {
                Automarke.Audi => 5,
                Automarke.BMW => 7,
                Automarke.Porsche => 22,
                _ => -1, // der unterstrich entspricht dem default
            };

            // Schleifen

            while (DateTime.Now.Second % 2 == 0)
            {
                // solange bedingung wahr ist wird der inhalt der while ausgeführt
                // vor jedem durchlauf wird geprüft
            }

            do
            {
                // erst wird ausgeführt, danach gestestet ob wiederholt werden soll
            } while (DateTime.Now.Second % 2 == 0); // Spongebob: wanna see me do it again? :D


            //   vor dem ersten durchlauf; vor jedem durchlauf; nach jedem durchlauf
            for (int counter = 0; counter < 5; counter++)
            {
                Console.WriteLine(counter);
            }
            // 0 1 2 3 4

            // alle einstellungen in der for-schleife sind optional
            for (;;) // Endloschleife,  "Zoidberg for" :D
            {
                if (DateTime.Now.Second % 2 == 0)
                {
                    break; // bricht eine schleife ab
                }
            }


            List<int> ZahlenListe = new();
            ZahlenListe.Add(5);
            ZahlenListe.Add(3);
            ZahlenListe.Add(2);

            // geht eine Collection von anfang bis ende durch, element für element
            // das aktiv
            foreach (var item in ZahlenListe)
            {
                Console.WriteLine(item);
            }

        }

    }

    enum Automarke
    {
        Audi,
        BMW,
        Porsche
    }
}
