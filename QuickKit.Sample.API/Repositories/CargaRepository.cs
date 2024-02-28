using Dapper;
using QuickKit.Repositories.Base;
using QuickKit.Sample.API.Entities;
using QuickKit.Sample.API.Validatos;
using QuickKit.Shared.Handlers;
using System.Data;

namespace QuickKit.Sample.API.Repositories;

public class CargaRepository : Repository<CargaEntity, int>, ICargaRepository
{
    public CargaRepository(CargaValidator validator, IDatabaseConnectionHandler handler) : base(validator, handler)
    {
    }

    public override async Task<int> AddAsync(CargaEntity entity)
    {
        var command = new CommandDefinition(ProcedureNameAdd, new { entity.Id, entity.Ativo }, commandType: CommandType.StoredProcedure);
        return await ExecuteAsync(entity, command, "carga inválida");
    }

    public override async Task<int> DeleteAsync(int id)
    {
        var entity = await GetByIdThrowAsync(id, "carga não encontrada");

        var command = new CommandDefinition(ProcedureNameDelete, new { id }, commandType: CommandType.StoredProcedure);

        return await ExecuteAsync(entity, command, "carga inválida");
    }

    public override async Task<IEnumerable<CargaEntity>> GetAllAsync()
    {
        return await QueryAsync<CargaEntity>(new CommandDefinition(ProcedureNameGetAll, commandType: CommandType.StoredProcedure));
    }

    public override async Task<CargaEntity?> GetByIdAsync(int id)
    {
        return await QuerySingleOrDefaultAsync<CargaEntity>(new CommandDefinition(ProcedureNameGetById, new { id }, commandType: CommandType.StoredProcedure));
    }

    public override Task<int> UpdateAsync(CargaEntity entity)
    {
        var command = new CommandDefinition(ProcedureNameUpdate, new { entity.Id, entity.Ativo }, commandType: CommandType.StoredProcedure);
        return ExecuteAsync(entity, command, "carga inválida");
    }
}
