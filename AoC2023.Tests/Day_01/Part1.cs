namespace AoC2023.Tests.Day_01;

[TestFixture]
public class Part1
{
    private const string FileName = "Day_01/Input.txt";

    [Test]
    public async Task Part1_ShouldReturn142()
    {
        const long expected = 142;

        var result = await Day01.Part1(FileName);

        result.Should().Be(expected);
    }
}
