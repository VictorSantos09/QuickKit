using Classroom.Core.Entities;
using Classroom.Core.Services;
using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Attributes;
using QuickKit.AspNetCore.Controllers;
using System.Net;

namespace Classroom.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassroomValueObjectController : Controller<ClassroomEntity, int>
    {
        private readonly IClassroomServiceValueObject _service;

        public ClassroomValueObjectController(IClassroomServiceValueObject service)
        {
            _service = service;
        }

        [HttpAddKit]
        public override async Task<IActionResult> AddAsync(ClassroomEntity entity)
        {
            var result = await _service.AddAsync(entity);
            return result.Convert(Ok);
        }

        [HttpDeleteKit]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result.Convert(Ok);
        }

        [HttpGetAllKit]
        public override async Task<IActionResult> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGetByIdKit]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result.Convert(HttpStatusCode.BadRequest);
        }

        [HttpGetTestEndPointKit]
        public override IActionResult TestEndPoint()
        {
            return Ok($"{nameof(ClassroomValueObjectController)} is working");
        }

        [HttpUpdateKit]
        public override async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
        {
            var result = await _service.UpdateAsync(entity);

            return result.Convert(HttpStatusCode.BadRequest);
        }
    }
}
