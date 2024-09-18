namespace QuickKit.Shared.UnitTests.Extensions;

public class ObjectExtensionTests
{
    [Fact]
    public void IsNull_WhenObjectNull_ShouldReturnTrue()
    {
        // Arrange
        object? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenStringNull_ShouldReturnTrue()
    {
        // Arrange
        string? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenIntNull_ShouldReturnTrue()
    {
        // Arrange
        int? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDoubleNull_ShouldReturnTrue()
    {
        // Arrange
        double? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenFloatNull_ShouldReturnTrue()
    {
        // Arrange
        int? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDecimalNull_ShouldReturnTrue()
    {
        // Arrange
        decimal? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDateTimeNull_ShouldReturnTrue()
    {
        // Arrange
        DateTime? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenDateOnlyNull_ShouldReturnTrue()
    {
        // Arrange
        DateOnly? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenTimeOnlyNull_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNull_WhenBoolNull_ShouldReturnTrue()
    {
        // Arrange
        bool? obj = null;
        bool expected = true;

        // Act
        bool actual = obj.IsNull();

        // Assert
        Assert.Equal(expected, actual);
    }
}
