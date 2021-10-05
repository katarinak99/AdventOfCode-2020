using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day01
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var numbers = File.ReadAllLines("day01.txt")
                .Select(int.Parse)
                .ToList();

            Part01(numbers);
            Part02(numbers);
        }

        private static void Part01(IReadOnlyList<int> numbers)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = i + 1; j < numbers.Count; j++)
                {
                    var first = numbers[i];
                    var second = numbers[j];
                    var sum = first + second;

                    if (sum != 2020) continue;

                    Console.WriteLine(first * second);
                    return;
                }
            }
        }

        private static void Part02(IReadOnlyList<int> numbers)
        {
            for (var i = 0; i < numbers.Count - 2; i++)
            {
                for (var j = i + 1; j < numbers.Count - 1; j++)
                {
                    for (var k = j + 1; k < numbers.Count; k++)
                    {
                        var first = numbers[i];
                        var second = numbers[j];
                        var third = numbers[k];
                        var sum = first + second + third;

                        if (sum != 2020) continue;
                        Console.WriteLine(first * second * third);
                        return;
                    }
                }
            }
        }
    }
}
