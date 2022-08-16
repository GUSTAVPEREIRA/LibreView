using Core.Library.Models;

namespace Core.Library;

public interface ICategoryRepository
{
    public Task Delete(int id);
    public Task<CategoryResponse> CreateCategory(CategoryCreateRequest categoryCreateRequest);
    public Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest categoryCreateRequest);
}