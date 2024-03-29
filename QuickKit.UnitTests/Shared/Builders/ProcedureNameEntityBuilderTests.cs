﻿using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.UnitTests.Shared.TestsEntities;

namespace QuickKit.UnitTests.Shared.Builders;
public class ProcedureNameEntityBuilderTests
{
    private readonly ProcedureNameBuilderUpdateStrategy<ValidNameTestEntity> _procedureNameBuilderUpdateStrategy;
    private readonly ProcedureNameBuilderAddStrategy<ValidNameTestEntity> _procedureNameBuilderAddStrategy;
    private readonly ProcedureNameBuilderDeleteStrategy<ValidNameTestEntity> _procedureNameBuilderDeleteStrategy;
    private readonly ProcedureNameBuilderGetAllStrategy<ValidNameTestEntity> _procedureNameBuilderGetAllStrategy;
    private readonly ProcedureNameBuilderGetByIdStrategy<ValidNameTestEntity> _procedureNameBuilderGetByStrategy;

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
        Assert.Equal("SP_VALIDNAMETEST_UPDATE", _procedureNameBuilderUpdateStrategy.Build());
        Assert.Equal("SP_VALIDNAMETEST_ADD", _procedureNameBuilderAddStrategy.Build());
        Assert.Equal("SP_VALIDNAMETEST_DELETE", _procedureNameBuilderDeleteStrategy.Build());
        Assert.Equal("SP_VALIDNAMETEST_GETALL", _procedureNameBuilderGetAllStrategy.Build());
        Assert.Equal("SP_VALIDNAMETEST_GETBYID", _procedureNameBuilderGetByStrategy.Build());
    }
}
