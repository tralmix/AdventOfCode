namespace AoC2025.Tests
{
    public class Day01
    {
        [Test]
        public async Task Part1_WithProvidedInput_ReturnsExpected()
        {
            // Arrange - input lines from your prompt
            (string, int)[] input =
			[
				("L", 68),
                ("L", 30),
                ("R", 48),
                ("L", 5),
                ("R", 60),
                ("L", 55),
                ("L", 1),
                ("L", 99),
                ("R", 14),
                ("L", 82)
            ];

            // Act - call the production method directly (project reference required)
            var result = await AoC2025.Day01.Part1(input);

            // Assert - expected value set to 3
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void ParseLine_ParsesValidLine_ReturnsExpectedTuple()
        {
            // Arrange
            var parser = AoC2025.Day01.ParseLine;

            // Act
            var (direction, distance) = parser("L68");

			Assert.Multiple(() =>
			{
				// Assert
				Assert.That(direction, Is.EqualTo("L"));
				Assert.That(distance, Is.EqualTo(68));
			});
		}

        [Test]
        public void ParseLine_InvalidLine_ThrowsFormatException()
        {
            // Arrange
            var parser = AoC2025.Day01.ParseLine;

            // Act & Assert
            Assert.Throws<FormatException>(() => parser("invalid"));
        }
    }
}
