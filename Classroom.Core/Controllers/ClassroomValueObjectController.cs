using Classroom.Core.Entities;
using Classroom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.AspNetCore.Controllers;
using QuickKit.ResultTypes.Converters;
using System.Net;

namespace Classroom.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassroomValueObjectController : ControllerBase, IController<ClassroomEntity, int>
    {
        private readonly IClassroomServiceValueObject _service;

        public ClassroomValueObjectController(IClassroomServiceValueObject service)
        {
            _service = service;
        }

        [Add]
        public async Task<IActionResult> AddAsync(ClassroomEntity entity)
        {
            var result = await _service.AddAsync(entity);
            return result.Convert(Ok);
        }

        [Delete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result.Convert(Ok);
        }

        [GetAll]
        public async Task<ActionResult<IEnumerable<ClassroomEntity>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [GetById]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.Convert(HttpStatusCode.BadRequest);
        }

        [TestEndPoint]
        public IActionResult TestEndPoint()
        {
            return Ok($"{nameof(ClassroomValueObjectController)} is working");
        }

        [Update]
        public   async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
        {
            var result = await _service.UpdateAsync(entity);

            return result.Convert(HttpStatusCode.BadRequest);
        }
    }
}
