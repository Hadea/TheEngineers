using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class InputConversion
    {
        public static void DoSomething()
        {
            List<int> aLotOfNumbers = new List<int>();

            string userInput = Console.ReadLine();

            int convertedNumber;

            do
            {
                Console.WriteLine("Bitte Zahl eingeben");
            } while (int.TryParse(userInput, out convertedNumber));
            Console.WriteLine("Zahl akzeptiert");
            aLotOfNumbers.Add(convertedNumber);
        }
    }
}
