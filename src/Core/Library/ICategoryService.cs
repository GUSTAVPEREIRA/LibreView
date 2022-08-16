using Core.Library.Models;

namespace Core.Library;

public interface ICategoryService
{
    public Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest);
    public Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest);
    public Task DeleteCategoryAsync(int id);
}