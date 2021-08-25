using System;
using System.Collections.Generic;

namespace Wiederholung
{
    static class InputConversion
    {
        public static void DoSomething()
        {
            List<int> aLotOfNumbers = new();
            string userInput;
            int convertedNumber;

            do
            {
                Console.WriteLine("Bitte Zahl eingeben");
                userInput = Console.ReadLine(); // Text wird von der Konsole eingelesen bis Enter gedrückt wird. Alle Zeichen werden in einem String gesammelt und zurückgegeben.
            } while (!int.TryParse(userInput, out convertedNumber)); // Konvertiert einen string in einen int. Wenn die Konvertierung klappt gibt die methode true zurück.
            Console.WriteLine("Zahl akzeptiert");
            aLotOfNumbers.Add(convertedNumber); // die Zahl wird in die Liste eingefügt.
        }
    }
}
