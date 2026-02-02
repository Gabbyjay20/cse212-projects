using System;
using week03.code;

namespace week03.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Week 3 Demo ===\n");

            // Test FindPairs
            Console.WriteLine("1. Testing FindPairs:");
            string[] words = { "am", "at", "ma", "if", "fi" };
            string[] pairs = SetsAndMaps.FindPairs(words);
            Console.WriteLine($"Found {pairs.Length} pairs:");
            foreach (string pair in pairs)
            {
                Console.WriteLine($"  {pair}");
            }

            // Test IsAnagram
            Console.WriteLine("\n2. Testing IsAnagram:");
            Console.WriteLine($"CAT vs ACT: {SetsAndMaps.IsAnagram("CAT", "ACT")}");
            Console.WriteLine($"DOG vs GOOD: {SetsAndMaps.IsAnagram("DOG", "GOOD")}");
            Console.WriteLine($"Ab vs Ba: {SetsAndMaps.IsAnagram("Ab", "Ba")}");
            Console.WriteLine($"tom marvolo riddle vs i am lord voldemort: {SetsAndMaps.IsAnagram("tom marvolo riddle", "i am lord voldemort")}");

            // Test SummarizeDegrees
            Console.WriteLine("\n3. Testing SummarizeDegrees:");
            var degrees = SetsAndMaps.SummarizeDegrees("../code/census.txt");
            Console.WriteLine($"Degrees: {degrees.Count}");
            foreach (var kvp in degrees)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }

            // Test EarthquakeDailySummary
            Console.WriteLine("\n4. Testing EarthquakeDailySummary:");
            var earthquakes = SetsAndMaps.EarthquakeDailySummary();
            Console.WriteLine($"Found {earthquakes.Length} earthquakes in the last 24 hours:");
            for (int i = 0; i < Math.Min(5, earthquakes.Length); i++)
            {
                Console.WriteLine($"  {earthquakes[i]}");
            }
            if (earthquakes.Length > 5)
            {
                Console.WriteLine($"  ... and {earthquakes.Length - 5} more");
            }

            // Test Maze
            Console.WriteLine("\n5. Testing Maze:");
            var maze = new Maze(SetupMazeMap());
            Console.WriteLine(maze.GetStatus());
            try
            {
                maze.MoveUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"  Can't move up: {ex.Message}");
            }
            maze.MoveRight();
            Console.WriteLine(maze.GetStatus());
            maze.MoveDown();
            Console.WriteLine(maze.GetStatus());

            Console.WriteLine("\n=== Demo Complete ===");
        }

        private static Dictionary<ValueTuple<int, int>, bool[]> SetupMazeMap()
        {
            Dictionary<ValueTuple<int, int>, bool[]> map = new() {
                { (1, 1), new[] { false, true, false, true } },
                { (1, 2), new[] { false, true, true, false } },
                { (1, 3), new[] { false, false, false, false } },
                { (1, 4), new[] { false, true, false, true } },
                { (1, 5), new[] { false, false, true, true } },
                { (1, 6), new[] { false, false, true, false } },
                { (2, 1), new[] { true, false, false, true } },
                { (2, 2), new[] { true, false, true, true } },
                { (2, 3), new[] { false, false, true, true } },
                { (2, 4), new[] { true, true, true, false } },
                { (2, 5), new[] { false, false, false, false } },
                { (2, 6), new[] { false, false, false, false } },
                { (3, 1), new[] { false, false, false, false } },
                { (3, 2), new[] { false, false, false, false } },
                { (3, 3), new[] { false, false, false, false } },
                { (3, 4), new[] { true, true, false, true } },
                { (3, 5), new[] { false, false, true, true } },
                { (3, 6), new[] { false, false, true, false } },
                { (4, 1), new[] { false, true, false, false } },
                { (4, 2), new[] { false, false, false, false } },
                { (4, 3), new[] { false, true, false, true } },
                { (4, 4), new[] { true, true, true, false } },
                { (4, 5), new[] { false, false, false, false } },
                { (4, 6), new[] { false, false, false, false } },
                { (5, 1), new[] { true, true, false, true } },
                { (5, 2), new[] { false, false, true, true } },
                { (5, 3), new[] { true, true, true, true } },
                { (5, 4), new[] { true, false, true, true } },
                { (5, 5), new[] { false, false, true, true } },
                { (5, 6), new[] { false, true, true, false } },
                { (6, 1), new[] { true, false, false, false } },
                { (6, 2), new[] { false, false, false, false } },
                { (6, 3), new[] { true, false, false, false } },
                { (6, 4), new[] { false, false, false, false } },
                { (6, 5), new[] { false, false, false, false } },
                { (6, 6), new[] { true, false, false, false } }
            };
            return map;
        }
    }
}