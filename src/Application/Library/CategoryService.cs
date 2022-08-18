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
        return await _categoryRepository.CreateCategoryAsync(categoryCreateRequest);
    }

    public async Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest)
    {
        return await _categoryRepository.UpdateCategoryAsync(categoryCreateRequest);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }

    public async Task<CategoryResponse> GetCategoryAsync(int id)
    {
        return await _categoryRepository.GetCategoryAsync(id);
    }
}