using OldPhonePad.Services;

namespace OldPhonePad.Tests;

public class OldPhonePadConverterTests
{
    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("222 2 22#", "CAB")]
    [InlineData("8 88777444666*664#", "TURING")]
    public void Convert_ReturnsExpectedResult(string input, string expected)
    {
        var result = OldPhonePadConverter.Convert(input);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_WithInvalidCharacter_Throws()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
            OldPhonePadConverter.Convert("23@4#"));

        Assert.Contains("Failed to convert input string due to invalid format or unexpected error", ex.Message);
    }

    [Fact]
    public void Convert_EmptyInput_ReturnsEmpty()
    {
        var result = OldPhonePadConverter.Convert("");
        Assert.Equal("", result);
    }
}
