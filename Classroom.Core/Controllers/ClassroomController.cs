using Classroom.Core.Entities;
using Classroom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.AspNetCore.Controllers;

namespace Classroom.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassroomController : Controller<ClassroomEntity, int>
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        /// <summary>
        /// Create a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Response</returns>
        [HttpAddKit]
        public override async Task<IActionResult> AddAsync(ClassroomEntity entity)
        {
            await _classroomService.AddAsync(entity);
            return Ok();
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDeleteKit]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            await _classroomService.DeleteAsync(id);
            return Ok();
        }

        [HttpGetAllKit]
        public override async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _classroomService.GetAllAsync());
        }

        [HttpGetByIdKit]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _classroomService.GetByIdAsync(id));
        }

        [HttpGetTestEndPointKit]
        public override IActionResult TestEndPoint()
        {
            return Ok($"{nameof(ClassroomController)} api working");
        }

        [HttpUpdateKit]
        public override async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
        {
            await _classroomService.UpdateAsync(entity);
            return Ok();
        }
    }
}
