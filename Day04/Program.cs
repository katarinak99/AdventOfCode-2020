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
        }
    }
}