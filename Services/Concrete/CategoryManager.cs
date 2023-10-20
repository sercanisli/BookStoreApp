using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public CategoryManager(IMapper mapper, ILoggerService logger, IRepositoryManager manager)
        {
            _mapper = mapper;
            _logger = logger;
            _manager = manager;
        }

        public async Task<CategoryDto> CreateOneCategoryAsync(CategoryDtoForInsertion categoryDtoForInsertion)
        {
            var entity = _mapper.Map<Category>(categoryDtoForInsertion);
            _manager.Category.CreateOneCategory(entity);
            await _manager.SaveAsync();
            return _mapper.Map<CategoryDto>(entity);
        }

        public async Task DeleteOneCategoryAsync(int id, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAsync(id, trackChanges);
            _manager.Category.DeleteOneCategory(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(trackChanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            return await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
        }

        public async Task UpdateOneCategoryAsync(int id, CategoryDtoForUpdate categoryDtoForUpdate, bool trackChanges)
        {
            var entity = await GetOneCategoryByIdAsync(id, trackChanges);
            entity = _mapper.Map<Category>(categoryDtoForUpdate);
            entity.CategoryId = id;

            _manager.Category.Update(entity);
            await _manager.SaveAsync();
        }
    }
}
