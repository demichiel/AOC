namespace AOC2
{
    public interface IRule
    {
        public int FirstArgument { get; set; }
        public int SecondArgument { get; set; }
        public char Character { get; set; }

        bool IsPasswordValid(string password);
    }
}