using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AOC4
{
    class Program
    {
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines("/home/michiel/dev/AOC/AOC4/input.txt").ToList();

            var passportLines = new List<string> {""};

            foreach (var line in allLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    passportLines.Add("");
                }
                else
                {
                    passportLines[^1] = string.Concat(passportLines.Last(), " ", line);
                }
            }
            
            passportLines.ForEach(Console.WriteLine);

            var passports = passportLines.Select(x => x.Trim()).Select(x => new Passport(x)).ToList();

            Console.WriteLine($"There are {passports.Count(x => x.AllFieldsPresent())} valid passports");

            Console.WriteLine($"There are {passports.Count(x => x.IsReallyValid())} really valid passports");
        }
    }

    public class Passport
    {
        public Dictionary<string, string> Dict { get; set; }

        public Passport(string passportLine)
        {
            var splitted = passportLine.Split(' ');
            var keyValues = splitted.Select(kv =>
            {
                var kvs = kv.Split(':');

                return new {Key = kvs[0], Value = kvs[1]};
            });
            Dict = keyValues.ToDictionary(x => x.Key, x => x.Value);
        }

        public bool AllFieldsPresent()
        {
            return Dict.ContainsKey("byr") && Dict.ContainsKey("iyr") && Dict.ContainsKey("eyr") && Dict.ContainsKey("hgt") &&
                Dict.ContainsKey("hcl") && Dict.ContainsKey("ecl") && Dict.ContainsKey("pid");
        }

        public bool IsReallyValid()
        {
            if (!AllFieldsPresent())
            {
                return false;
            }

            if (!int.TryParse(Dict["byr"], out var birthYear))
            {
                return false;
            }

            if (birthYear < 1920 || birthYear > 2020)
            {
                return false;
            }

            if (!int.TryParse(Dict["iyr"], out var issueYear))
            {
                return false;
            }

            if (issueYear < 2010 || issueYear > 2020)
            {
                return false;
            }

            if (!int.TryParse(Dict["eyr"], out var expirationYear))
            {
                return false;
            }

            if (expirationYear < 2020 || expirationYear > 2030)
            {
                return false;
            }

            if (Regex.IsMatch(Dict["hgt"], "^[0-9]+(cm|in)$"))
            {
                if (Dict["hgt"].Contains("in"))
                {
                    var inches = int.Parse(Dict["hgt"].TrimEnd('i', 'n', 'c', 'm'));

                    if (inches < 59 || inches > 76)
                    {
                        return false;
                    }
                }
                else
                {
                    var centimeters = int.Parse(Dict["hgt"].TrimEnd('i', 'n', 'c', 'm'));

                    if (centimeters < 150 || centimeters > 193)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            if (!Regex.IsMatch(Dict["hcl"], "^(#)([0-9A-Fa-f]{6})$"))
            {
                return false;
            }

            if (!Regex.IsMatch(Dict["ecl"], "^(amb|blu|brn|gry|grn|hzl|oth)$"))
            {
                return false;
            }

            if (!Regex.IsMatch(Dict["pid"], "^[0-9]{9}$"))
            {
                return false;
            }

            return true;
        }
    }
}