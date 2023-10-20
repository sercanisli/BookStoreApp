using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesControllers : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CategoriesControllers(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost(Name = "CreateOneCategoryAsync")]
        public async Task<IActionResult> CreateOneCategoryAsync([FromBody] CategoryDtoForInsertion categoryDtoForInsertion)
        {
            var category = await _manager.CategoryService.CreateOneCategoryAsync(categoryDtoForInsertion);
            return StatusCode(201, category);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneCategoryAsync([FromRoute(Name = "id")] int id, CategoryDtoForUpdate categoryDtoForUpdate)
        {
            await _manager.CategoryService.UpdateOneCategoryAsync(id, categoryDtoForUpdate,false);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneCategoryAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.CategoryService.DeleteOneCategoryAsync(id, false);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _manager.CategoryService.GetAllCategoriesAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryAsync([FromRoute(Name = "id")] int id)
        {
            return Ok(await _manager.CategoryService.GetOneCategoryByIdAsync(id, false));
        }
    }
}
