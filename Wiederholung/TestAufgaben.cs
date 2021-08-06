using System;
using System.Collections.Generic;

namespace Wiederholung
{
    static class TestAufgaben
    {
        public static void RaufzaehlenV1()
        {
            for (int counter = 3; counter < 22; counter += 3)
            {
                Console.Write("Zahl " + counter + " ist ");

                if (counter % 2 == 0)
                {
                    Console.WriteLine("gerade");
                }
                else
                {
                    Console.WriteLine("ungerade");
                }
            }
            /*

            Zahl 3 ist ungerade
            Zahl 6 ist gerade
            Zahl 9 ist ungerade
            Zahl 12 ist gerade
            Zahl 15 ist ungerade
            Zahl 18 ist gerade
            Zahl 21 ist ungerade

             */

        }

        public static int[] GetStatistics(byte[] byteArray)
        {
            int[] StatistikArray = new int[20];

            for (int counter = 0; counter < byteArray.Length; counter++)
            {
                StatistikArray[byteArray[counter]]++;
            }
            return StatistikArray;
        }

        public static void TestGetStatistics()
        {
            byte[] ByteArray = new byte[100_000_000];
            Random rndGen = new();
            for (int counter = 0; counter < ByteArray.Length; counter++)
            {
                ByteArray[counter] = (byte)rndGen.Next(0, 20);
            }

            // array wird befüllt mit werten ab 0 und kleiner 20
            int[] result = TestAufgaben.GetStatistics(ByteArray);

            for (int counter = 0; counter < result.Length; counter++)
            {
                Console.WriteLine($" {counter} => {result[counter]}");
            }
        }

        public static void RaufzaehlenV2()
        {
            for (int counter = 3; counter < 22; counter += 3)
                Console.WriteLine("Zahl " + counter + " ist " + (counter % 2 == 0 ? "gerade" : "ungerade"));
        }

        public static uint FibonacciRecursive(uint Number)
        {
            if (Number == 1 || Number == 2)
                return 1;
            return FibonacciRecursive(Number - 1) + FibonacciRecursive(Number - 2);
        }

        public static uint FibonacciLoop(uint Number)
        {
            if (Number == 0)
            {
                return 0;
            }

            if (Number == 1 || Number == 2)
            {
                return 1;
            }

            uint Alpha = 1;
            uint Bravo = 1;
            uint Summe = 0;

            for (int counter = 2; counter < Number; counter++)
            {
                Summe = Alpha + Bravo;
                Alpha = Bravo;
                Bravo = Summe;
            }

            return Summe;
        }

        public static void BenchmarkFibonacci()
        {

            uint[,] NumbersAndResults = new uint[3, 20]; // ein Array mit 3 zeilen und 20 spalten

            // erstellen eines Objektes vom Typ Random, welches wir zum erstellen von zufälligen Zahlen nutzen
            Random rndGen = new Random();

            for (int counter = 0; counter < 20; counter++)
            {
                //geht die oberste spalte des Array durch und füllt jedes fach mit einer zufälligen zahl
                NumbersAndResults[0, counter] = (uint)rndGen.Next(1, 48); // kleinster möglicher wert 1, grösster 47
            }

            DateTime startRecursive = DateTime.Now; // systemzeit speichern kurz vor dem rekursiven durchlauf

            // fibonacci durchlauf mit rekursion

            for (uint counter = 0; counter < 20; counter++)
            {
                // liesst den wert aus reihe 0 und spalte "counter", lässt ihn mit Fibonacci umrechnen und
                // speichert das Ergebnis in reihe 1 und spalte "counter"
                NumbersAndResults[1, counter] = FibonacciRecursive(NumbersAndResults[0, counter]);
            }

            DateTime endRecursiveStartLoop = DateTime.Now; // systemzeit speichern kurz nach dem rekursiven durchlauf und direkt vor dem loop

            for (uint counter = 0; counter < 20; counter++)
            {
                NumbersAndResults[2, counter] = FibonacciLoop(NumbersAndResults[0, counter]);
            }

            DateTime endLoop = DateTime.Now; // systemzeit nachdem der loop fertig ist


            Console.WriteLine("Statistik zu den Fibonacci-Varianten");
            Console.WriteLine("Es mussten " + NumbersAndResults.Length + " elemente berechnet werden");
            Console.WriteLine("Benötigte Zeit Rekursiv : " + (endRecursiveStartLoop - startRecursive).TotalSeconds);
            Console.WriteLine("Benötigte Zeit Loop     : " + (endLoop - endRecursiveStartLoop).TotalSeconds);


        }

        public static void IncrementTest()
        {
            // ++i wert vor der benutzung raufzählen und neuen wert nehmen
            // i++ wert nach der benutzung raufzählen und alten wert nehmen

            int a = 5; //6
            int b = 3; //4

            int ergebnis = ++b + ++a / b + a;
            // ergebnis 11 =  4 + (6 / 4) + 6
            // variablen werden der reihenfolge nach ausgerechnet und in die formel eingefügt
            // die formel wird dann nach mathematischer priorität abgearbeitet (klammern vor punkt vor strich)

            Console.WriteLine(ergebnis);
        }

        public static bool GetRandomAndEven(out int RandomNumber)
        {
            Random rndGen = new();
            RandomNumber = rndGen.Next();
            return RandomNumber % 2 == 0;
        }

        public static void TestGetRandomAndEven()
        {
            int Zahl = 5;

            Console.WriteLine("Wert von Zahl vor der Methode : " + Zahl);

            bool isEven;

            isEven = TestAufgaben.GetRandomAndEven(out Zahl);

            Console.WriteLine("Zahl ist gerade? : " + isEven);
            Console.WriteLine("Wert von Zahl nach der Methode: " + Zahl);
        }

        public static void FuellenUndTauschen()
        {
            /*
             * Array erstellen der länge 20
             * Zahlen ab 5 aufsteigend in das Array einfügen
             * Zahl in Fach 0 mit der in Fach 1 tauschen
             * Zahl in Fach 2 mit der in Fach 3 tauschen
             * Zahl in Fach 4 mit der in Fach 5 tauschen
             * ...
             * Zahl in Fach 18 mit der in Fach 19 tauschen
             * 
             * 
             *  5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 ...
             */
            int[] UebungArray = new int[20];
            for (int counter = 0; counter < UebungArray.Length; counter++)
                UebungArray[counter] = counter + 5;

            int backup;
            for (int counter = 0; counter < UebungArray.Length; counter += 2)
            {
                backup = UebungArray[counter];
                UebungArray[counter] = UebungArray[counter + 1];
                UebungArray[counter + 1] = backup;
            }
        }

        public static void SelectionSort()
        {
            // array erstellen
            byte[] numberArray = new byte[100];
            // zufallsgenerator erstellen
            Random rndGen = new();
            // array mit zufälligen werten füllen
            // byte-arrays können mit einem einzigen befehl vollständig befüllt werden
            // alle anderen benötigen eine schleife
            rndGen.NextBytes(numberArray);

            // array durchgehen bis zum vorletzen element
            for (int outer = 0; outer < numberArray.Length - 1; outer++)
            {
                // array duchgehen ab nachfolgeelement bis zum letzten element
                int lowest = outer;

                for (int inner = outer + 1; inner < numberArray.Length; inner++)
                {
                    // wenn element an innerer position kleiner als das an äusserer position
                    if (numberArray[outer] > numberArray[inner])
                    {
                        // elemente tauschen
                        lowest = inner;
                    }
                }
                if (lowest != outer)
                {
                    byte backup = numberArray[lowest];
                    numberArray[lowest] = numberArray[outer];
                    numberArray[outer] = backup;
                }
            }

            Console.WriteLine("Sortiertes Array : ");
            foreach (var item in numberArray)
            {
                Console.Write($" {item:D3}");
            }
        }

        public static void EuroJackpot()
        {
            List<byte> LottoZahlen = new(5);
            Random rndGen = new();
            byte possibleNumber;

            // 5 eindeutige Zahlen zufällig generieren, erste gültige ist die 1, letzte gültige ist 50
            do
            {
                possibleNumber = (byte)rndGen.Next(1, 51);
                if (!LottoZahlen.Contains(possibleNumber))
                {
                    LottoZahlen.Add(possibleNumber);
                }
            }
            while (LottoZahlen.Count < 5);

            // 2 eindeutige Zahlen zufällig generieren, erste gültige ist die 1, letzte gültige ist 10
            List<byte> ZusatzZahlen = new(2);
            ZusatzZahlen.Add((byte)rndGen.Next(1, 11));

            do
            {
                possibleNumber = (byte)rndGen.Next(1, 11);
            } while (possibleNumber == ZusatzZahlen[0]);
            ZusatzZahlen.Add(possibleNumber);
        }


        /*
         * Einen EuroJackpot Lottoschein mit zusatzzahlen erstellen
         * 
         * solange noch keine 5 sekunden vergangen sind
         *      zufälligen lottoschein generieren
         *      den lottoschein mit dem oben erstellten vergleichen
         *      Anzahl der richtigen zahlen in eine Trefferstatistik schreiben
         * ende solange
         * 
         * trefferstatistik ausgeben
         */
    }
}
