using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC6
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC6/input.txt").ToList();

            var concatGroups = new List<string>
            {
                ""
            };

            foreach (var line in allLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    concatGroups.Add("");
                }
                else
                {
                    concatGroups[^1] = string.Concat(concatGroups[^1], line);
                }
            }

            var allCounts = concatGroups.Select(x => x.ToCharArray().Distinct().Count());

            Console.Write("Part 1: ");
            Console.WriteLine(allCounts.Sum());

            var groups = new List<List<char[]>>
            {
                new()
            };

            foreach (var line in allLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    groups.Add(new List<char[]>());
                }
                else
                {
                    groups[^1].Add(line.ToCharArray());
                }
            }

            var everyoneAnswers = new List<int>();

            foreach (var group in groups)
            {
                var maxCount = group.Count();

                var allAnswers = new string(group.SelectMany(x => x).ToArray());

                var answerWithCount = allAnswers.GroupBy(x => x).Select(x => new
                {
                    Character = x.Key,
                    Count = x.Count()
                });

                everyoneAnswers.Add(answerWithCount.Count(x => x.Count == maxCount));
            }

            var sum = 0;
            everyoneAnswers.ForEach(a => sum += a);
            
            Console.Write("Part 2:");
            Console.WriteLine(sum);
        }
    }
}