using QuickKit.Sample.API.Entities;
using QuickKit.Sample.API.Repositories;

namespace QuickKit.Sample.API.Services;

public class CargaService : ICargaService
{
    private readonly ICargaRepository _cargaRepository;

    public CargaService(ICargaRepository cargoRepository)
    {
        _cargaRepository = cargoRepository;
    }

    public async Task AddAsync(CargaEntity entity)
    {
        await _cargaRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _cargaRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CargaEntity>> GetAllAsync()
    {
        return await _cargaRepository.GetAllAsync();
    }

    public async Task<CargaEntity> GetByIdAsync(int id)
    {
        return await _cargaRepository.GetByIdThrowAsync(id, "carga não encontrada");
    }

    public async Task UpdateAsync(CargaEntity entity)
    {
        await _cargaRepository.UpdateAsync(entity);
    }
}
