using System;
using System.IO;

namespace Wiederholung
{
    static class Dateien
    {
        public static void DoSomething()
        {
            // Überprüft ob die Datei HalloWelt.txt vorhanden ist
            bool doesFileExist = File.Exists("HalloWelt.txt");

            if (doesFileExist)
            {
                // liesst die Textdatei HalloWelt.txt vollständig ein und gibt sie als string zurück
                // Da die Datei keinen Ordner angegeben hat wird im gleichen verzeichnis wie die .exe gesucht
                string dataOfTextFile = File.ReadAllText("HalloWelt.txt");
                Console.WriteLine(dataOfTextFile);

                // liesst die Textdatei HalloWelt.txt vollständig ein und gibt sie als string-array zurück
                // jede Zeile in der Datei ist ein eintrag im Array
                string[] dataOfTextFileInLines = File.ReadAllLines("HalloWelt.txt");
                for (int i = dataOfTextFileInLines.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(dataOfTextFileInLines[i]);
                }
            }
            // Erstellt oder überschreibt eine datei. Der neue inhalt ist Hallo Welt!
            File.WriteAllText("HalloWelt.txt", "Hallo Welt!");

            if (File.Exists("Checker.bmp"))
            {
                // liesst eine binärdatei Checker.bmp vollständig ein und gibt sie als byte-array zurück
                byte[] dataOfBitmap = File.ReadAllBytes("Checker.bmp");

                foreach (var item in dataOfBitmap)
                {
                    Console.WriteLine(item);
                }
            }

            /// ab hier geht es um Streams

            using (FileStream stream = File.Open("HalloWelt.txt", FileMode.Open))
            {
                int[] fileData = new int[3];

                for (int counter = 0; counter < fileData.Length; counter++)
                {
                    // liesst ein einzelnes byte und speichert dies im Array
                    // das gelesene Byte wird dabei als integer verwendet!
                    fileData[counter] = stream.ReadByte();
                }

                stream.WriteByte(100); // schreibt ein kleines d an den aktuellen Index (3) der Datei

            } //Dispose() wird automatisch bei der schliessenden klammer gemacht, dadurch wird in diesem fall
            // der stream geschlossen stream.Close(); 



            // Öffnet eine Datei mit einem Stream (nur teile der datei im RAM).
            // Wenn nur lesevorgänge gemacht werden kann das betriebssystem mehrere lesevorgänge gleichzeitig
            // erlauben. Beim schreiben geht das nicht.
            // So wenig rechte wie möglich anfordern!
            // entspricht der Zeile File.Open("HalloWelt.txt", FileMode.Open, FileAccess.Read)
            using (FileStream stream = File.OpenRead("HalloWelt.txt"))
            {
                byte[] data = new byte[70]; // Ein Puffer welcher die Daten aufnehmen soll
                int byteCount = stream.Read(data);// liesst die daten vom stream in das array. Rückgabe ist die anzahl der gelesenen bytes
                Console.WriteLine($"Anzahl der gelesenen bytes : {byteCount}");

                for (int count = 0; count < byteCount; count++)
                {
                    Console.WriteLine(data[count].ToString("X"));
                }
            }


            // StreamReader und StreamWriter werden benutzt um über einen Stream eine Textdatei zu bearbeiten. Ungeeignet für Binärdateien

            using (StreamReader stream = new("HalloWelt.txt"))
            {
                stream.Read(); // liesst ein einzelnes zeichen aus dem stream
                char[] buffer = new char[5];
                int charCount = stream.ReadBlock(buffer); // liesst daten in ein Array
                string zeile = stream.ReadLine(); // liesst bis zum nächsten Zeilenumbruch in einen string
                string rest = stream.ReadToEnd(); // liesst den gesamten restlichen inhalt in einen string
            }

            using (StreamWriter stream = new("HalloWelt.txt")) // öffnet eine textdatei mit schreibrechten. es können auch optionen angegeben werden wie anhängen oder das Encoding
            {
                stream.WriteLine(@"Hallo Welt!"); // schreibt die Zeile in die datei und macht danach einen Zeilenumbruch
                stream.Write(127); // konvertiert den parameter in einen string und schreibt diesen in die datei
            }
        }
    }
}
