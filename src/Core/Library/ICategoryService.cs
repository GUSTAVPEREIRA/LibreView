using Core.Library.Models;
using Core.Pagination;

namespace Core.Library;

public interface ICategoryService
{
    public Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest);
    public Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest);
    public Task DeleteCategoryAsync(int id);
    public Task<CategoryResponse> GetCategoryAsync(int id);

    public Task<PagedResult<CategoryResponse>> GetCategoriesByFilters(
        PagedRequest<CategoryFiltersRequest> pagedRequest);
}