using Classroom.Core.Entities;
using Classroom.Core.Repositories;
using Classroom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.AspNetCore.Controllers;
using QuickKit.AspNetCore.Controllers.Contracts;

namespace Classroom.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase,
    IController<ClassroomEntity, int>
{
    private readonly IClassroomService _classroomService;
    private readonly IClassroomRepository _classroomRepository;

    public ClassroomController(IClassroomService classroomService, IClassroomRepository classroomRepository)
    {
        _classroomService = classroomService;
        _classroomRepository = classroomRepository;
    }

    /// <summary>
    /// Create a entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Response</returns>
    [Add]
    public async Task<IActionResult> AddAsync(ClassroomEntity entity)
    {
        await _classroomService.AddAsync(entity);
        return Ok();
    }

    /// <summary>
    /// Delete a entity
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Delete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _classroomService.DeleteAsync(id);
        return Ok();
    }

    [GetAll]
    public async Task<ActionResult<IEnumerable<ClassroomEntity>>> GetAllAsync()
    {
        return Ok(await _classroomService.GetAllAsync());
    }

    [GetById]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _classroomService.GetByIdAsync(id));
    }

    [TestEndPoint]
    public IActionResult TestEndPoint()
    {
        return Ok($"{nameof(ClassroomController)} api working");
    }

    [Update]
    public async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
    {
        await _classroomService.UpdateAsync(entity);
        return Ok();
    }
}
