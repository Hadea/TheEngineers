using System;

namespace ListTests
{
    public class Queue
    {
        public Queue(int MinimumSize = 90000)
        {
            data = new int[MinimumSize];
            ReadPointer = 0;
            WritePointer = 0;
            userDefinedMinimum = MinimumSize;
        }

        protected int userDefinedMinimum;

        public int Count { get; protected set; }
        public int Capacity
        {
            get => data.Length;
            set
            {
                userDefinedMinimum = value;
                resize(value);
            } //value ist der parameter der set methode für Capacity
        }

        private void resize(int value)
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException(nameof(value));
            if (value < Count)
                throw new InsufficientMemoryException();

            int[] newArray = new int[value]; // array erstellen mit neuer grösse
            int newArrayWritePointer = 0;
            int oldCount = Count;
            while (Count > 0)// solange noch daten in der Queue sind
            {
                newArray[newArrayWritePointer++] = retrieveData();//      element auslesen und in neuem array speichern
            }// ende solange

            readPointer = 0; // readPointer auf den anfang setzen
            writePointer = oldCount; // writepointer auf das ende +1 setzen
            Count = oldCount;
            data = newArray; // altes array mit neuem überschreiben
        }

        protected int ReadPointer
        {
            get
            {
                return readPointer;
            }
            set // der neue wert landet in value. Entspricht void ReadPointer_Set(int value)
            {
                readPointer = (value < Capacity ? value : 0);  //  (bedingung?true:false )
            }
        }
        int readPointer;

        protected int WritePointer
        {
            get => writePointer;
            set => writePointer = (value < Capacity ? value : 0);
        }
        int writePointer;

        protected int[] data;
        public void Push(int DataToAdd)
        {
            if (Count == Capacity)
            {
                resize(Capacity*2);
            }
            Count++;
            data[WritePointer++] = DataToAdd;
        }

        public int Pop()
        {
            if (Count < 1) throw new IndexOutOfRangeException();
            if (Count < Capacity / 3 && Capacity / 2 >= userDefinedMinimum)
                resize(Capacity / 2);
            
            return retrieveData();
        }

        protected int retrieveData()
        {
            Count--;
            return data[ReadPointer++];
        }

        public void ForEach(Action<int> methodToStartForEachElement)
        {
            while (Count > 0)
            {
                methodToStartForEachElement(Pop());
            }
        }
    }
}
