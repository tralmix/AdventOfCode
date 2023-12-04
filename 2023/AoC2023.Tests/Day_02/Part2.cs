namespace AoC2023.Tests.Day_02;
public class Part2
{
    private const string FileName = "Day_02/Input.txt";

    [Test]
    public async Task Part2_ShouldReturn_2286()
    {
        const long expected = 2286;

        var result = await Day02.Part2(FileName);

        result.Should().Be(expected);
    }
}
