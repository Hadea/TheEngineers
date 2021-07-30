using System;
using System.Collections.Generic;

namespace Wiederholung
{
    class Datentypen
    {
        // Ganze zahlen

        long GanzeZahl8ByteMitVorzeichen; // -9 Trilliarden bis +9 Trilliarden
        ulong GanzeZahl8ByteOhneVorzeichen; // 0 bis +18 Trilliarden

        int GanzeZahl4ByteMitVorzeichen; // -2,14 Milliarden bis +2,14 Milliarden, häufigster Datentyp
        uint GanzeZahl4ByteOhneVorzeichen; // 0 bis +4,29 Milliarden  "unsigned integer"

        short GanzeZahl2ByteMitVorzeichen; // -32 Tausend bis +32 Tausend
        ushort GanzeZahl2ByteOhneVorzeichen; // 0 bis 65535 , beliebt bei Netzwerk

        byte GanzeZahl1ByteOhneVorzeichen; // 0 bis 255
        sbyte GanzeZahl1ByteMitVorzeichen; // -128 bis +127

        // Gebrochene Zahlen

        float GebrocheneZahl4Byte; // 5 bis 7 stellen
        double GebrocheneZahl8Byte; // 13 stellen
        decimal GebrocheneZahl16Byte; // 25 stellen, Vorsicht! Decimal ist in SQL eine ganze Zahl

        // Text
        char Zeichen = 'B'; // 2Byte
        
        string LiteralString = @"Hallo\n \t \\ Welt"; // eigendlich am häufigsten genutzt, aber gern wird das @ weggelassen
        string Zeichenkette = "Hallo\n \t \\ Welt"; // 2Byte je Buchstabe + Länge
        string CommandString = $"Hallo {DateTime.Now} \n \t";// zusätzlich zum normalen string sind in geschweiften Klammern befehle möglich

        // Bit
        bool EinzelnesBit = true; // kann true oder false sein

        public static void StringExample()
        {
            string systemInformation;
            Console.WriteLine("\n\nCommand-String mit $");
            systemInformation = $"Hallo\nDie Systemzeit ist: {DateTime.Now}\nAnzahl der Prozessoren: {Environment.ProcessorCount} {1 + 1}";
            Console.WriteLine(systemInformation);

            Console.WriteLine("\n\nNormaler String");
            systemInformation = "Hallo\nDie Systemzeit ist: {DateTime.Now}\nAnzahl der Prozessoren: {Environment.ProcessorCount} {1 + 1}";
            Console.WriteLine(systemInformation);
            
            Console.WriteLine("\n\nLiteral String mit @");
            systemInformation = @"Hallo\nDie Systemzeit ist: {DateTime.Now}\nAnzahl der Prozessoren: {Environment.ProcessorCount} {1 + 1}";
            Console.WriteLine(systemInformation);
        }

    }
}
