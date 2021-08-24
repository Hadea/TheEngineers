using System;

namespace ListTests
{
    internal class List : IContainer
    {
        protected int[] data;

        public List()
        {
            data = new int[8];
        }


        public int Capacity
        {
            get => data.Length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Count
        {
            get => _count;
        }
        protected int _count;

        public void Add(int Number)
        {
            if (Count == Capacity) // prüfen ob wir noch platz haben
            {
                int[] resizedArray = new int[Capacity * 2];
                for (int i = 0; i < data.Length; i++)
                {
                    resizedArray[i] = data[i];
                }
                data = resizedArray;
            }

            data[Count] = Number;
            _count++;
        }

        public int Get(int Index)
        {
            if (Index >= Count || Index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return data[Index];
        }
    }
}