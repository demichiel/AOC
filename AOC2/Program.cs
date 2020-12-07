using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC2/input.txt").ToList();

            var firstRuleCombinations = new List<(RuleOne rule, string pw)>();

            var secondRuleCombinations = new List<(RuleTwo rule, string pw)>();

            foreach (var splitLine in allLines.Select(line => line.Split('-', ':', ' ')))
            {
                firstRuleCombinations.Add((new RuleOne
                {
                    FirstArgument = int.Parse(splitLine[0]),
                    SecondArgument = int.Parse(splitLine[1]),
                    Character = char.Parse(splitLine[2])
                }, splitLine[4]));

                secondRuleCombinations.Add((new RuleTwo
                {
                    FirstArgument = int.Parse(splitLine[0]),
                    SecondArgument = int.Parse(splitLine[1]),
                    Character = char.Parse(splitLine[2])
                }, splitLine[4]));
            }

            Console.WriteLine(
                $"First rule has {firstRuleCombinations.Count(combination => combination.rule.IsPasswordValid(combination.pw))} valid passwords");

            Console.WriteLine(
                $"Second rule has {secondRuleCombinations.Count(combination => combination.rule.IsPasswordValid(combination.pw))} valid passwords");
        }
    }
}