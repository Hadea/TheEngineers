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
            #region Array

            // Feste grösse. Grundbaustein fast aller anderen Container
            // Alle elemente direkt hintereinander im RAM
            // Vorderstes element ist 0, letztes ist in diesem fall 9
            byte[] ByteArray;
            ByteArray = new byte[10];
            Console.WriteLine( ByteArray[7] + ByteArray[2] );
            // index 0 1 2 3 4 5 6 7 8 9
            // value 0 0 0 0 0 0 0 0 0 0

            #endregion
            #region Multidimensionales Array

            // Legt ein mehrdimensionales Array an welches mit koordinatenpaaren adressiert wird.
            // die Anzahl der Dimensionen ist dabei frei wählbar, aber vorsicht beim RAM-Verbrauch
            // Technisch gesehen ist es noch immer ein eindimensionales Array das durch arithmetik
            // funktioniert wie ein mehrdimensionales Array
            // 0123
            // 4567
            // liegt im RAM hintereinander
            // 01234567

            //                                          Y X
            byte[,] ByteArrayZweidimensional = new byte[7,3];
            Console.WriteLine( ByteArrayZweidimensional[1,2]);

            #endregion
            #region List

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
            #endregion
            #region LinkedList
            LinkedList<int> LinkedListOfInteger = new();
            // Erstellt eine linkedlist. In dieser sind die inhalte wie an einer kette aufgereiht.
            // ein element kennt die position des nachfolgers und vorgängers (Double Linked List).
            // Dadurch das die elemente im RAM verstreut sind ist kein direkter zugriff auf ein einzelnes
            // element möglich sodass die Element-Kette von vorn durchgegangen werden muss um auf ein
            // element zuzugreifen.
            // Vorteil der LinkedList ist das jederzeit einzelne elemente aus der kette entfernt oder
            // auch an beliebiger stelle hinzugefügt werden können.

            LinkedListOfInteger.Clear(); // löscht die Elemente aus der LinkedList
            LinkedListOfInteger.AddLast(1); // fügt ein element ans ende der Elementkette
            LinkedListOfInteger.AddFirst(2); // fügt ein element an den anfang der Elementkette
            LinkedListNode<int> foundNode = LinkedListOfInteger.Find(2); // gibt das erste kettenglied zurück welches dem suchbegriff entspricht
            LinkedListOfInteger.AddAfter(foundNode, 5); // fügt hinter einem element ein weiteres ein
            LinkedListOfInteger.AddBefore(foundNode, 7); // fügt hinter einem element ein weiteres ein
            LinkedListOfInteger.Remove(foundNode); // löscht ein element aus der LinkedList
            LinkedListOfInteger.RemoveFirst(); // löscht das erste element der LinkedList
            LinkedListOfInteger.RemoveLast(); // löscht das letzte element der LinkedList

            foundNode.Value = 2; // ändert den Inhalt eines Elements
            LinkedListNode<int> nodeAfter = foundNode.Next; // in Next und Previous sind die angrenzenden Nodes
            // gespeichert. Sollte diese Referenz null sein is das ende der kette erreicht


            // zum iterieren über den gesamten Inhalt einer LinkedList sollte die ForEach-Schleife genutzt werden
            // durch den Iterator welcher immer die position des nächsten elements kennt muss für einen zugriff
            // nicht die kette jedes mal durchgegangen werden.

            foreach (var node in LinkedListOfInteger)
            {
                Console.WriteLine(node);
            }
            #endregion

        }

    }
}
