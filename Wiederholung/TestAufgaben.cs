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

        public static void RaufzaehlenV2()
        {
            for (int counter = 3; counter < 22; counter += 3)
                Console.WriteLine("Zahl " + counter + " ist " + (counter % 2 == 0 ? "gerade" : "ungerade"));
        }
    }
}
