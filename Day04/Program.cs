using System.Text.RegularExpressions;

namespace Day04
{
    class Program
    {
        private static readonly List<string> RequiredFields = new()
        {
            "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"
        };

        private static void Main()
        {
            var input = File.ReadAllText("input04.txt");
            var passports = input.Split("\n\n");

            var result = passports
                .Count(passport => RequiredFields.All(passport.Contains));

            Console.WriteLine(result);

            var items = new Regex("(\\s+)");
            var color = new Regex("#[0-9a-f]{6}");
            var pidRegex = new Regex("[0-9]{9}");
            var count = 0;
            foreach (var passport in passports)
            {
                var fields = items.Split(passport);
                var dictionary = new Dictionary<string, string>();
                foreach (var field in fields)
                {
                    var parts = field.Split(":");
                    dictionary[parts[0]] = parts[1];
                }

                if (int.Parse(dictionary["byr"]) is < 1920 or > 2002 ||
                    int.Parse(dictionary["iyr"]) is < 2010 or > 2020 ||
                    int.Parse(dictionary["eyr"]) is < 2020 or > 2030 ||
                    !color.IsMatch(dictionary["hcl"]) ||
                    !"amb blu brn gry grn hzl oth".Contains(dictionary["ecl"]) ||
                    !pidRegex.IsMatch(dictionary["pid"]) ||
                    InvalidHeight(dictionary["hgt"]))
                {
                    continue;
                }

                count++;
            }
            Console.WriteLine(count);
        }

        private static bool InvalidHeight(string s)
        {
            var notNumber = new Regex("[^\\d]");
            var notUnit = new Regex("[^incm]");
            var height = int.Parse(notNumber.Replace(s, ""));
            var unit = notUnit.Replace(s, "");

            return unit switch
            {
                "cm" => height is < 150 or > 193,
                "in" => height is < 59 or > 76,
                _ => true
            };
        }
    }

    internal record Passport(string birth, string issue, string expiration, string height, string hair, string eye,
        string pid);
}