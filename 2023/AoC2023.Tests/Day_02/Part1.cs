namespace AoC2023.Tests.Day_02;

[TestFixture]
public class Part1
{
    private const string FileName = "Day_02/Input.txt";
    [Test]
    public async Task Part1_ShouldReturn_8()
    {
        const long expected = 8;

        var result = await Day02.Part1(FileName);

        result.Should().Be(expected);
    }
}
