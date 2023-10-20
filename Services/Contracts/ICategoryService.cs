using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDtoForInsertion);
        Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDtoForUpdate, bool trackChanges);
        Task DeleteOneCategoryAsync(int id, bool trackChanges);
    }
}
