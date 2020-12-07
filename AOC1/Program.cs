using System;
using System.IO;
using System.Linq;

namespace AOC1
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        static void Part1()
        {
            var numbers = File.ReadAllLines("/home/michiel/dev/AOC/AOC1/input.txt")
                .ToList().Select(x => int.Parse(x)).ToList();

            foreach (var number in numbers)
            {
                var toFind = 2020 - number;
                if (numbers.IndexOf(toFind) != -1)
                {
                    Console.WriteLine($"{number} + {toFind} = 2020");

                    Console.WriteLine($"{number} * {toFind} = {number * toFind}");
                    break;
                }
            }
        }

        static void Part2()
        {
            var numbers = File.ReadAllLines("/home/michiel/dev/AOC/AOC1/input.txt")
                .ToList().Select(x => int.Parse(x)).ToArray();

            int a = 0;
            int b = 0;
            int c = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                for (int j = 0; j < numbers.Count(); j++)
                {
                    for (int k = 0; k < numbers.Count(); k++)
                    {
                        if (i != j && i != k && j != k)
                        {
                            if (numbers[i] + numbers[j] + numbers[k] == 2020)
                            {
                                a = numbers[i];
                                b = numbers[j];
                                c = numbers[k];
                                break;
                            }
                        }

                    }
                }
            }

            Console.WriteLine($"{a} + {b} + {c} = 2020");

            Console.WriteLine($"{a} * {b} * {c} = {a * b * c}");
        }
    }
}
