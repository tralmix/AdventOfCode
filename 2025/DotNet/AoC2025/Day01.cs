using AoC2025.Extensions;
using System.Text.RegularExpressions;

namespace AoC2025;

public static partial class Day01
{
	private const string DefaultInputFile = "Inputs/Day01.txt";
	private const int StartPosition = 50;

	[GeneratedRegex(@"^(?<direction>[LR])(?<distance>\d+)$")]
	private static partial Regex InputLineParserRegex();

	public static async Task Solve()
	{
		Console.WriteLine("Day 1");

		var input = await ParseFile();

		int part1Result = await Part1(input);
		Console.WriteLine($"Day 01 - Part 1: {part1Result}");

		//int part2Result = await Part2(input);
		//Console.WriteLine($"Day 01 - Part 2: {part2Result}");
	}

	private static async Task<(string, int)[]> ParseFile(string inputFile = DefaultInputFile)
	{
		var lines = await File.ReadAllLinesAsync(inputFile);

		var parsedInput = lines.Select(ParseLine).ToArray();

		return parsedInput;
	}

	public static (string direction, int distance) ParseLine(string line)
	{
		var match = InputLineParserRegex().Match(line);
		if (!match.Success)
		{
			throw new FormatException($"Invalid input line format: {line}");
		}
		var direction = match.Groups["direction"].Value;
		var distance = int.Parse(match.Groups["distance"].Value);
		return (direction, distance);
	}

	public static async Task<int> Part1((string, int)[] input)
	{
		var position = StartPosition;
		var timesStoppedAtZero = 0;

		foreach (var (direction, distance) in input)
		{
			int initialPosition = position;
			int initialTimesStoppedAtZero = timesStoppedAtZero;
			position = MoveDial(position, direction, distance);

			if (position == 0)
			{
				timesStoppedAtZero++;
			}

			Console.WriteLine($"Moved {direction}{distance} from {initialPosition} to {position}. Times stopped at zero: {initialTimesStoppedAtZero} -> {timesStoppedAtZero}");
		}

		return timesStoppedAtZero;
	}

	private static int MoveDial(int position, string direction, int distance)
	{
		position = direction switch
		{
			"L" => MoveLeft(position, distance),
			"R" => MoveRight(position, distance),
			_ => throw new InvalidOperationException($"Unknown direction: {direction}"),
		};
		return position;
	}

	private static async Task<int> Part2((string, int)[] input)
	{
		throw new NotImplementedException();
	}

	private static int MoveLeft(int position, int distance)
	{
		var newPosition = position - (distance%100);

		if (newPosition.IsNegative())
		{
			newPosition += 100;
		}

		return newPosition;
	}

	private static int MoveRight(int position, int distance)
	{
		var newPosition = position + (distance % 100);

		if (newPosition > 99)
		{
			newPosition -= 100;
		}

		return newPosition;
	}
}
