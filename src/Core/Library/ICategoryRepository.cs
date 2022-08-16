using Core.Library.Models;

namespace Core.Library;

public interface ICategoryRepository
{
    public Task DeleteAsync(int id);
    public Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest);
    public Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest);
    public Task<CategoryResponse> GetCategoryAsync(int id);
}