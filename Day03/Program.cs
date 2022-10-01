namespace Day03
{
    internal record Slope(int x, int y);

    class Program
    {
        private static void Main()
        {
            var lines = File.ReadAllLines("input03.txt")
                .ToList();
            // Part 1
            var result = FindTrees(lines, new Slope(3, 1));
            Console.WriteLine(result);

            // Part 2
            var slopes = new List<Slope>
            {
                new Slope(1, 1),
                new Slope(3, 1),
                new Slope(5, 1),
                new Slope(7, 1),
                new Slope(1, 2)
            };
            result = slopes.Aggregate(1, (current, slope) => current * FindTrees(lines, slope));
            Console.WriteLine(result);
        }

        private static int FindTrees(List<string> lines, Slope slope)
        {
            var trees = 0;
            var x = 0;
            for (var i = slope.y; i < lines.Count; i += slope.y)
            {
                x += slope.x;
                x %= lines[i].Length;
                if (lines[i][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}