namespace ListTests
{
    interface IContainer
    {
        public int Count { get; }
        public int Capacity { get; set; }
        public void Add(int Number);
        public int Get(int Index);
    }
}
