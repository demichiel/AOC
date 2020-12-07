using System.Linq;

namespace AOC2
{
    class RuleOne : IRule
    {
        public int FirstArgument { get; set; }
        public int SecondArgument { get; set; }
        public char Character { get; set; }

        public bool IsPasswordValid(string password)
        {
            return password.Count(x => x == Character) >= FirstArgument &&
                   password.Count(x => x == Character) <= SecondArgument;
        }
    }
}