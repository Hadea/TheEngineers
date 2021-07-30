using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiederholung
{
    class Container
    {
        void DoSomething()
        {

            // Feste grösse. Grundbaustein fast aller anderen Container
            // Alle elemente direkt hintereinander im RAM
            // Vorderstes element ist 0, letztes ist in diesem fall 9
            byte[] ByteArray;
            ByteArray = new byte[10];
            Console.WriteLine( ByteArray[7] + ByteArray[2] );
            // index 0 1 2 3 4 5 6 7 8 9
            // value 0 0 0 0 0 0 0 0 0 0


            //                                          Y X
            byte[,] ByteArrayZweidimensional = new byte[7,3];
            Console.WriteLine( ByteArrayZweidimensional[1,2]);


            // Wie Array, aber grössenänderungen werden automatisch vollzogen.
            // Alle elemente direkt hintereinander im RAM
            List<byte> ByteList = new();
            ByteList.Add(5);
            ByteList.Add(9);
            ByteList.Add(2);
            ByteList.Add(7);
            ByteList.Add(2);

            Console.WriteLine(ByteList[4]);
            // index 0 1 2 3 4
            // value 5 9 2 7 2

        }

    }
}
