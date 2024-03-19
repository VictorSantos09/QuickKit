using QuickKit.Shared.Builders;
using QuickKit.UnitTests.Shared.TestsEntities;

namespace QuickKit.UnitTests.Shared.Builders;
public class ProcedureNameEntityBuilderTests
{
    private readonly string Update = ProcedureNameEntityBuilder<ValidNameTestEntity>.Update;
    private readonly string Add = ProcedureNameEntityBuilder<ValidNameTestEntity>.Add;
    private readonly string Delete = ProcedureNameEntityBuilder<ValidNameTestEntity>.Delete;
    private readonly string GetAll = ProcedureNameEntityBuilder<ValidNameTestEntity>.GetAll;
    private readonly string GetById = ProcedureNameEntityBuilder<ValidNameTestEntity>.GetById;
    private readonly string ExistsById = ProcedureNameEntityBuilder<ValidNameTestEntity>.ExistsById();

    [Fact]
    public void Builder_WhenCalled_ShouldReturnProcedureNameWithoutEntity()
    {
        // Assert
        Assert.Equal("sp_validnametest_update", Update);
        Assert.Equal("sp_validnametest_add", Add);
        Assert.Equal("sp_validnametest_delete", Delete);
        Assert.Equal("sp_validnametest_getAll", GetAll);
        Assert.Equal("sp_validnametest_getById", GetById);
        Assert.Equal("sp_validnametest_existsById", ExistsById);
    }
}
