using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC5
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC5/input.txt").ToList();

            var boardingPasses = allLines.Select(x => new BoardingPass
            {
                Code = x.ToCharArray()
            }).ToList();
            
            boardingPasses.ForEach(Console.WriteLine);

            Console.WriteLine(boardingPasses.Max(x => x.SeatId));

            var allSeatIds = boardingPasses.Select(x => x.SeatId).ToList();

            var minSeatId = allSeatIds.Min();
            var maxSeatId = allSeatIds.Max();

            Console.WriteLine(minSeatId);
            Console.WriteLine(maxSeatId);

            for (int i = minSeatId; i <= maxSeatId; i++)
            {
                if (!allSeatIds.Contains(i))
                {
                    Console.WriteLine($"Your seat is {i}");
                }
            }
        }
    }

    public class BoardingPass
    {
        public char[] Code { get; set; }

        public string RowAsBinary
        {
            get
            {
                return new string(Code.ToList().Take(7).Select(x => x == 'F' ? '0' : '1').ToArray());
            }
        }

        public string SeatAsBinary
        {
            get
            {
                return new(Code.ToList().Skip(7).Select(x => x == 'L' ? '0' : '1').ToArray());
            }
        }

        public int Row => Convert.ToInt32(RowAsBinary, 2);

        public int Seat => Convert.ToInt32(SeatAsBinary, 2);

        public int SeatId => (Row * 8) + Seat;

        public override string ToString()
        {
            return $"Seat {new string(Code)} is {RowAsBinary} in binary. Row {Row}, seat {Seat}, id {SeatId}";
        }
    }
}