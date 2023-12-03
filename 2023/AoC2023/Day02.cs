using System.Xml.Serialization;

namespace AoC2023;
public class Day02
{
    private static readonly string FileName = "Inputs/Day02.txt";

    private static readonly int MaxBlue = 14;
    private static readonly int MaxGreen = 13;
    private static readonly int MaxRed = 12;

    public static async Task Run()
    {

        Console.WriteLine("Day 1");

        var part1Answer = await Part1(FileName);
        Console.WriteLine($"The sum of the game ids is {part1Answer}.");

        //var part2Answer = await Part2(FileName);
        //Console.WriteLine($"The sum of the updated calibration values is {part2Answer}.");

        Console.WriteLine();
    }

    public static async Task<long> Part1(string fileName)
    {
        var games = await ParseFile(fileName);

        var validGames = games.Where(g =>
            g.MaxBlue <= MaxBlue &&
            g.MaxGreen <= MaxGreen &&
            g.MaxRed <= MaxRed
            );

        var result = validGames.Select(_ => _.Id).Sum();

        return result;
    }

    public static async Task<long> Part2(string fileName)
    {
        throw new NotImplementedException();
    }

    private static async Task<List<Game>> ParseFile(string fileName)
    {
        var lines = await File.ReadAllLinesAsync(fileName);

        var games = lines.Select(BuildGame).ToList();

        return games;
    }

    private static Game BuildGame(string input, int index)
    {
        var game = new Game { Id = index + 1 };

        var startOfSetString = input.IndexOf(':') + 1;
        var setString = input[startOfSetString..].Trim();
        var sets = setString.Split(';');

        game.Sets = sets.Select(BuildSet).ToList();

        return game;
    }

    private static Set BuildSet(string input, int index)
    {
        var set = new Set();
        var colors = input.Split(',').Select(_=>_.Trim());

        foreach(var item in colors)
        {
            var parts = item.Split(' ').Select(_ => _.Trim()).ToArray();
            var count = int.Parse(parts[0]);
            var color = parts[1];

            switch (color)
            {
                case "blue": 
                    if(count > set.Blue)
                        set.Blue = count;
                    break;
                case "green": 
                    if(count > set.Green)
                        set.Green = count;
                    break;
                case "red": 
                    if(count > set.Red)
                        set.Red = count;
                    break;
                default: throw new NotImplementedException($"No solution available for the color {color}");
            }
        }

        return set;
    }

    public class Game
    {
        public int Id { get; set; }

        public List<Set> Sets { get; set; } = [];

        public int MaxBlue => Sets.Select(_=> _.Blue).Max();
        public int MaxGreen => Sets.Select(_=> _.Green).Max();
        public int MaxRed => Sets.Select(_=> _.Red).Max();
    }

    public class Set
    {
        public int Blue { get; set; }
        public int Green { get; set; }
        public int Red { get; set; }
    }
}
