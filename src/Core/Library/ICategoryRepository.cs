using Core.Library.Models;
using Core.Pagination;

namespace Core.Library;

public interface ICategoryRepository
{
    public Task DeleteAsync(int id);
    public Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest);
    public Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest);
    public Task<CategoryResponse> GetCategoryAsync(int id);
    public Task<PagedResult<CategoryResponse>> GetCategories(PagedRequest<CategoryFiltersRequest> filtersRequest);
}