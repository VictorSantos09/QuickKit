using QuickKit.Shared.Extensions;

namespace QuickKit.Shared.UnitTests.Extensions;

public class StringExtensionTests
{
    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData(null)]
    public void IsEmpty_ShouldReturnTrue(string value)
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = value.IsEmpty();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsEmpty_WhenDefaultStringEmpty_ShouldReturnTrue()
    {
        // Arrange
        bool expected = true;

        // Act
        bool actual = string.Empty.IsEmpty();

        // Assert
        Assert.Equal(expected, actual);
    }
}
