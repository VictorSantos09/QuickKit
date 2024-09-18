using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.UnitTests.Shared.TestsEntities;
using Xunit;

namespace QuickKit.UnitTests.Shared.Builders;
public class ProcedureNameEntityBuilderTests
{
    private readonly ProcedureNameBuilderUpdateStrategy _procedureNameBuilderUpdateStrategy;
    private readonly ProcedureNameBuilderAddStrategy _procedureNameBuilderAddStrategy;
    private readonly ProcedureNameBuilderDeleteStrategy _procedureNameBuilderDeleteStrategy;
    private readonly ProcedureNameBuilderGetAllStrategy _procedureNameBuilderGetAllStrategy;
    private readonly ProcedureNameBuilderGetByIdStrategy _procedureNameBuilderGetByStrategy;

    public ProcedureNameEntityBuilderTests()
    {
        _procedureNameBuilderUpdateStrategy = new();
        _procedureNameBuilderAddStrategy = new();
        _procedureNameBuilderDeleteStrategy = new();
        _procedureNameBuilderGetByStrategy = new();
        _procedureNameBuilderGetAllStrategy = new();

    }

    [Fact]
    public void Builder_WhenCalled_ShouldReturnProcedureNameWithoutEntity()
    {
        // Assert
        Assert.Equal("SP_VALIDNAMETEST_UPDATE", _procedureNameBuilderUpdateStrategy.Build<ValidNameTestEntity>());
        Assert.Equal("SP_VALIDNAMETEST_ADD", _procedureNameBuilderAddStrategy.Build<ValidNameTestEntity>());
        Assert.Equal("SP_VALIDNAMETEST_DELETE", _procedureNameBuilderDeleteStrategy.Build<ValidNameTestEntity>());
        Assert.Equal("SP_VALIDNAMETEST_GETALL", _procedureNameBuilderGetAllStrategy.Build<ValidNameTestEntity>());
        Assert.Equal("SP_VALIDNAMETEST_GETBYID", _procedureNameBuilderGetByStrategy.Build<ValidNameTestEntity>());
    }
}
