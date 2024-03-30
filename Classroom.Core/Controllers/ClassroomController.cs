using Classroom.Core.Entities;
using Classroom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.ResultTypes;
using QuickKit.ResultTypes.Converters;
using System.Net;

namespace Classroom.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase, IController<ClassroomEntity, int>
{
    private readonly IClassroomService _service;

    public ClassroomController(IClassroomService service)
    {
        _service = service;
    }

    [Add]
    public async Task<IActionResult> AddAsync(ClassroomEntity entity)
    {
        Final result = await _service.AddAsync(entity);
        return result.Convert(Ok);
    }

    [Delete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        Final result = await _service.DeleteAsync(id);
        return result.Convert(Ok);
    }

    [GetAll]
    public async Task<ActionResult<IEnumerable<ClassroomEntity>>> GetAllAsync()
    {
        Final<IEnumerable<ClassroomEntity>> result = await _service.GetAllAsync();
        return Ok(result);
    }

    [GetById]
    public async Task<ActionResult<ClassroomEntity>> GetByIdAsync(int id)
    {
        Final<ClassroomEntity> result = await _service.GetByIdAsync(id);
        return result.Convert(HttpStatusCode.BadRequest);
    }

    [TestEndPoint]
    public IActionResult TestEndPoint()
    {
        return Ok($"{nameof(ClassroomController)} is working");
    }

    [Update]
    public async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
    {
        Final result = await _service.UpdateAsync(entity);

        return result.Convert(HttpStatusCode.BadRequest);
    }
}
