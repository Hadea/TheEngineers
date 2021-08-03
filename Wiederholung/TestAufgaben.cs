using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class TestAufgaben
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

        // 9 8 7 1 8 9 2 4 8 9 4 7 8 9 4 2 9 4 7 4 5 2 9 4 8 4 5 2 4
        // 0 => 0
        // 1 => 1
        // 2 => 1
        // 3 => 0
        // 4 => 1
        // 5 => 0
        // 6 => 0
        // 7 => 1
        // 8 => 3
        // 9 => 2


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


        //Aufgabe: Fibonacci
        // parameter   1 2 3 4 5 6  7  8  9 10 .. 
        // return      1 1 2 3 5 8 13 21 34 55 ..

        // Methode schreiben welche eine Zahl entgegennimmt und die fibonacci-zahl
        // dazu ausrechnet und zurückgibt


        // rekursiv:
        // fibonacci anfrage kleiner als 3 ist immer 1
        // fibonacci der zahl 5 ist die summe aus fibonacci 5-1 und fibonacci 5-2

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
                NumbersAndResults[0,counter] = (uint)rndGen.Next(1, 48); // kleinster möglicher wert 1, grösster 47
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
    }
}
