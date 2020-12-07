namespace AOC2
{
    class RuleTwo : IRule
    {
        public int FirstArgument { get; set; }
        public int SecondArgument { get; set; }
        public char Character { get; set; }

        public bool IsPasswordValid(string password)
        {
            return (password[FirstArgument - 1] == Character && password[SecondArgument - 1] != Character) ||
                   (password[FirstArgument - 1] != Character && password[SecondArgument - 1] == Character);
        }
    }
}