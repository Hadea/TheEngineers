using System;

namespace ListTests
{
    public class List : List<int> {}

    public class List<DataType>
    {
        protected DataType[] data;

        public List()
        {
            data = new DataType[8];
        }


        public int Capacity
        {
            get => data.Length;
            set
            {
                if (value <= 0 || value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Neue Kapazität war ausserhalb des gültigen bereichs");
                }

                DataType[] resizedArray = new DataType[value];
                for (int i = 0; i < pCount; i++)
                {
                    resizedArray[i] = data[i];
                }
                data = resizedArray;

            }
        }

        public int Count
        {
            get => pCount;
        }
        protected int pCount;

        public void Add(DataType Number)
        {
            if (Count == Capacity) // prüfen ob wir noch platz haben
            {
                Capacity *= 2;
            }

            data[Count] = Number;
            pCount++;
        }

        public DataType Get(int Index)
        {
            if (Index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Index), "Angeforderter Index war grösser als der Füllstand der List");
            }

            if (Index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Index),"Angeforderter Index war zu klein");
            }

            return data[Index];
        }

        public void Clear()
        {
            /*
            for (int index = 0; index < pCount; index++)
            {
                data[index] = 0;
            }
            */
            pCount = 0;
        }
    }
}