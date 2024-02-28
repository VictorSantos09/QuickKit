using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.Sample.API.Entities;
using QuickKit.Sample.API.Services;

namespace QuickKit.Sample.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CargaController : ControllerBase
{
    private readonly ICargaService _cargaService;

    public CargaController(ICargaService cargaService)
    {
        _cargaService = cargaService;
    }

    [HttpAddKit]
    [Authorize]
    public async Task<IActionResult> AddAsync(CargaEntity entity)
    {
        await _cargaService.AddAsync(entity);
        return Ok();
    }

    [HttpDeleteKit]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _cargaService.DeleteAsync(id);
        return Ok();
    }

    [HttpGetAllKit]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _cargaService.GetAllAsync());
    }

    [HttpGetByIdKit]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _cargaService.GetByIdAsync(id));
    }

    [HttpGetTestEndPointKit]
    public IActionResult TestEndPoint()
    {
        return Ok($"{nameof(CargaController)} funcionando");
    }

    [HttpUpdateKit]
    public async Task<IActionResult> UpdateAsync(CargaEntity entity)
    {
        await _cargaService.UpdateAsync(entity);
        return Ok();
    }
}
