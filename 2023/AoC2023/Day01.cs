using System.Text.RegularExpressions;

namespace AoC2023;

public partial class Day01
{
    private static readonly string FileName = "Inputs/Day01.txt";


    [GeneratedRegex(@"\d")]
    private static partial Regex Part1Regex();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine")]
    private static partial Regex Part2Regex();

    public static async Task Run()
    {
        Console.WriteLine("Day 1");

        var part1Answer = await Part1(FileName);
        Console.WriteLine($"The sum of the calibration values is {part1Answer}.");

        // Getting 55189 but answer is too low.
        var part2Answer = await Part2(FileName);
        Console.WriteLine($"The sum of the updated calibration values is {part2Answer}.");

        Console.WriteLine();
    }

    public static async Task<long> Part1(string fileName)
    {
        var result = await CalculateCalibration(fileName, Part1Regex());

        return result;
    }

    public static async Task<long> Part2(string fileName)
    {
        var result = await CalculateCalibration(fileName, Part2Regex());

        return result;
    }

    private static async Task<long> CalculateCalibration(string fileName, Regex regex)
    {
        var input = await ParseFile(fileName);

        var numbers = input.Select(_ => ParseNumber(_, regex));

        var result = numbers.Sum();

        return result;
    }

    public static async Task<string[]> ParseFile(string fileName)
    {
        var lines = await File.ReadAllLinesAsync(fileName);

        return lines;
    }

    private static int ParseNumber(string input, Regex regex)
    {
        var numbers = regex.Matches(input);

        var first = ParseLexicalNumber(numbers[0].Value);
        var last = ParseLexicalNumber(numbers[^1].Value);

        var result = BuildNumber(first, last);

        //Console.WriteLine($"Input {input} \n\tmatched on {numbers[0].Value} & {numbers[^1].Value} \n\tresulting in calibration value {result}");

        return result;
    }

    private static int BuildNumber(int first, int second)
    {
        return first * 10 + second;
    }

    private static int ParseLexicalNumber(string input)
    {
        return input switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(input)
        };
    }
}
