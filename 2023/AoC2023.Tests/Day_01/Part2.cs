namespace AoC2023.Tests.Day_01;

[TestFixture]
public class Part2
{
    private const string FileName = "Day_01/Input2.txt";

    [Test]
    public async Task Part2_ShouldReturn_281()
    {
        const long expected = 281;

        var result = await Day01.Part2(FileName);

        result.Should().Be(expected);
    }
}
