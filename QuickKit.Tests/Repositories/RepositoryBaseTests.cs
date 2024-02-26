using NSubstitute;
using QuickKit.Repositories.Base;
using QuickKit.Tests.Repositories.TestEntities;

namespace QuickKit.Tests.Repositories;
public class RepositoryBaseTests
{
    private readonly IRepository<PersonEntity, int> _sut = Substitute.For<IRepository<PersonEntity, int>>();

    [Fact]
    public async Task Add_ShouldComplete()
    {
        // Arrange
        _ = _sut.AddAsync(Arg.Any<PersonEntity>()).Returns(1);

        // Act
        var actual = await _sut.AddAsync(new PersonEntity());
        var expected = 1;

        // Assert
        Assert.Equal(expected, actual);

    }
}
