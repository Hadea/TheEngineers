namespace ListTests
{
    internal class List : IContainer
    {
        private int[] data;
        public List()
        {
            data = new int[100];
        }

        public int Count = 0;

        public void Add(int Number)
        {
            data[Count] = Number;
            Count++;
        }

        public int Get(int Index)
        {
            return data[Index];
        }
    }
}