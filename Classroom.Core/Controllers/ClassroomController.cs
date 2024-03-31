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
    public async Task<IActionResult> AddAsync(ClassroomEntity entity, CancellationToken cancellationToken)
    {
        Final result = await _service.AddAsync(entity, cancellationToken);
        return result.Convert(Ok);
    }

    [Delete]
    public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
    {

        Final result = await _service.DeleteAsync(id, cancellationToken);
        return result.Convert(Ok);

    }

    [GetAll]
    public async Task<ActionResult<IEnumerable<ClassroomEntity>>> GetAllAsync(CancellationToken cancellationToken)
    {
        Final<IEnumerable<ClassroomEntity>> result = await _service.GetAllAsync(cancellationToken);
        return Ok(result);
    }

    [GetById]
    public async Task<ActionResult<ClassroomEntity>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        Final<ClassroomEntity> result = await _service.GetByIdAsync(id, cancellationToken);
        return result.Convert(HttpStatusCode.BadRequest);
    }

    [TestEndPoint]
    public IActionResult TestEndPoint(CancellationToken cancellationToken)
    {
        return Ok($"{nameof(ClassroomController)} is working");
    }

    [Update]
    public async Task<IActionResult> UpdateAsync(ClassroomEntity entity, CancellationToken cancellationToken)
    {
        Final result = await _service.UpdateAsync(entity, cancellationToken);

        return result.Convert(HttpStatusCode.BadRequest);
    }
}
