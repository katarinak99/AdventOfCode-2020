using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input02.txt")
                .Select(Spec.Parse);
            
            Console.WriteLine(lines.Count(password => Part01(password)));
        }


        private static bool Part01(Spec spec)
        {
            var regex = @"[^" + spec.Character + "]";
            var reduced = Regex.Replace(spec.Password, regex, "");
            return reduced.Length >= spec.First && reduced.Length <= spec.Second;
        }
    }

    internal class Spec
    {
        public readonly int First;
        public readonly int Second;
        public readonly char Character;
        public readonly string Password;

        private Spec(int first, int second, char character, string password)
        {
            this.First = first;
            this.Second = second;
            this.Character = character;
            this.Password = password;
        }

        public static Spec Parse(string line)
        {
            var items = line.Split(": ");
            var ruleParts = items[0].Split(" ");
            var repeats = ruleParts[0].Split("-")
                .Select(int.Parse)
                .ToList();
            return new Spec(repeats[0], repeats[1], ruleParts[1][0], items[1]);
        }
    }
}
