using Core.Library;
using Core.Library.Models;

namespace Application.Library;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest)
    {
        return await _categoryRepository.CreateCategory(categoryCreateRequest);
    }

    public async Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest)
    {
        return await _categoryRepository.UpdateCategory(categoryCreateRequest);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.Delete(id);
    }
}