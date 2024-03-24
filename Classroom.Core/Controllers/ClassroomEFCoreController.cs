using Classroom.Core.Config.Context;
using Classroom.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickKit.AspNetCore.Controllers;

namespace Classroom.Core.Controllers
{
    public class ClassroomEFCoreController : Controller<ClassroomEntity, int>
    {
        private readonly AppDbContext _dbContext;

        public ClassroomEFCoreController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IActionResult> AddAsync(ClassroomEntity entity)
        {
            await _dbContext.AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            
            return Ok(result);
        }

        public override async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _dbContext.Classrooms.SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Classrooms.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return Ok(result);
        }

        public  async override Task<IActionResult> GetAllAsync()
        {
            var result = _dbContext.Classrooms.ToList();
            return Ok(result);
        }

        public async override Task<IActionResult> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Classrooms.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(entity);
        }

        public override IActionResult TestEndPoint()
        {
            return Ok($"{nameof(ClassroomEFCoreController)} is working");
        }

        public override async Task<IActionResult> UpdateAsync(ClassroomEntity entity)
        {
            var entityFound = await _dbContext.Classrooms.SingleOrDefaultAsync(x => x.Id == entity.Id);
            entityFound.ClassroomName = entity.ClassroomName;

            _dbContext.Update(entityFound);
            await _dbContext.SaveChangesAsync();
            return Ok(entityFound);
        }
    }
}
