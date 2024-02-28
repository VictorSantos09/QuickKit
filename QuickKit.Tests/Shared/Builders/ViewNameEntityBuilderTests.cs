using QuickKit.Shared.Builders;
using QuickKit.Tests.Shared.TestsEntities;

namespace QuickKit.Tests.Shared.Builders;
public class ViewNameEntityBuilderTests
{
    [Fact]
    public void Build_shouldReturnViewNameWithoutEntity()
    {
        // Act
        var viewName = ViewNameEntityBuilder<ValidNameTestEntity>.All;

        // Assert
        Assert.Equal("vw_validnametest_all", viewName);
    }
}
