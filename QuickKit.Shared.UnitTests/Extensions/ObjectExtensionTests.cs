using QuickKit.Shared.Extensions;

namespace QuickKit.Shared.UnitTests.Extensions;

public class ObjectExtensionTests
{
    [Fact]
    public void IsNull_WhenObjectNull_ShouldReturnTrue()
    {
        // Arrange
        object obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenStringNull_ShouldReturnTrue()
    {
        // Arrange
        string obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenIntNull_ShouldReturnTrue()
    {
        // Arrange
        int? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDoubleNull_ShouldReturnTrue()
    {
        // Arrange
        double? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenFloatNull_ShouldReturnTrue()
    {
        // Arrange
        int? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDecimalNull_ShouldReturnTrue()
    {
        // Arrange
        decimal? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDateTimeNull_ShouldReturnTrue()
    {
        // Arrange
        DateTime? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDateOnlyNull_ShouldReturnTrue()
    {
        // Arrange
        DateOnly? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenTimeOnlyNull_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenBoolNull_ShouldReturnTrue()
    {
        // Arrange
        bool? obj = null;
        var expected = true;

        // Act
        var actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }
}
