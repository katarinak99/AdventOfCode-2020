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
            
            Console.WriteLine(CommonPart(lines, Part01));
            Console.WriteLine(CommonPart(lines, Part02));
        }

        private static long CommonPart(IEnumerable<Spec> specs, Predicate<Spec> isValid)
        {
            return specs.Count(password => isValid(password));
        }

        private static bool Part01(Spec spec)
        {
            var regex = @"[^" + spec.Character + "]";
            var reduced = Regex.Replace(spec.Password, regex, "");
            return reduced.Length >= spec.First && reduced.Length <= spec.Second;
        }

        private static bool Part02(Spec spec)
        {
            return spec.Password[spec.First - 1] == spec.Character ^
                   spec.Password[spec.Second - 1] == spec.Character;
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
