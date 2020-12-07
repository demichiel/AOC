using System;
using System.IO;
using System.Linq;

namespace AOC3
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC3/input.txt").ToList();

            var rows = allLines.Count;

            var columns = allLines[0].Length;

            var theMap = new Map(rows, columns);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    theMap.TreeMap[i, j] = allLines[i][j] == '#';
                }
            }

            theMap.PrintMap();

            var countTrees = 0;

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees++;
                }

                theMap.Advance2();
            }

            Console.WriteLine("Problem 1:");
            Console.WriteLine($"The tobbogan hit {countTrees} trees");
            Console.WriteLine("#####################################");
            Console.WriteLine("#####################################");


            var countTrees1 = 0L;
            theMap.ResetPosition();

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees1++;
                }

                theMap.Advance1();
            }

            var countTrees2 = 0L;
            theMap.ResetPosition();

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees2++;
                }

                theMap.Advance2();
            }

            var countTrees3 = 0L;
            theMap.ResetPosition();

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees3++;
                }

                theMap.Advance3();
            }

            var countTrees4 = 0L;
            theMap.ResetPosition();

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees4++;
                }

                theMap.Advance4();
            }

            var countTrees5 = 0L;
            theMap.ResetPosition();

            while (!theMap.EndReached)
            {
                if (theMap.IsCurrentPositionATree())
                {
                    countTrees5++;
                }

                theMap.Advance5();
            }

            Console.WriteLine("Problem 2:");
            Console.WriteLine(
                $"{countTrees1} * {countTrees2} * {countTrees3} * {countTrees4} * {countTrees5} = {countTrees1 * countTrees2 * countTrees3 * countTrees4 * countTrees5}");
        }
    }

    public class Map
    {
        public (int x, int y) CurrentPosition { get; set; } = (0, 0);

        public int Rows { get; }
        public int Columns { get; }

        public bool EndReached { get; set; }

        public bool[,] TreeMap { get; }

        public Map(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            TreeMap = new bool[rows, columns];
        }

        public bool IsCurrentPositionATree()
        {
            return TreeMap[CurrentPosition.y, CurrentPosition.x];
        }

        public void ResetPosition()
        {
            CurrentPosition = (0, 0);
            EndReached = false;
        }

        public void Advance1()
        {
            if (CurrentPosition.y + 1 >= Rows)
            {
                EndReached = true;
            }
            else
            {
                CurrentPosition = ((CurrentPosition.x + 1) % Columns, (CurrentPosition.y + 1));
            }
        }

        public void Advance2()
        {
            if (CurrentPosition.y + 1 >= Rows)
            {
                EndReached = true;
            }
            else
            {
                CurrentPosition = ((CurrentPosition.x + 3) % Columns, (CurrentPosition.y + 1));
            }
        }

        public void Advance3()
        {
            if (CurrentPosition.y + 1 >= Rows)
            {
                EndReached = true;
            }
            else
            {
                CurrentPosition = ((CurrentPosition.x + 5) % Columns, (CurrentPosition.y + 1));
            }
        }

        public void Advance4()
        {
            if (CurrentPosition.y + 1 >= Rows)
            {
                EndReached = true;
            }
            else
            {
                CurrentPosition = ((CurrentPosition.x + 7) % Columns, (CurrentPosition.y + 1));
            }
        }

        public void Advance5()
        {
            if (CurrentPosition.y + 1 >= Rows)
            {
                EndReached = true;
            }
            else
            {
                CurrentPosition = ((CurrentPosition.x + 1) % Columns, (CurrentPosition.y + 2));
            }
        }

        public void PrintMap()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(TreeMap[i, j] ? "#" : " ");
                }

                Console.WriteLine();
            }
        }
    }
}