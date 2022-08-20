using AutoMapper;
using Core.Library;
using Core.Library.Models;
using Core.Pagination;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    private IMapper Mapper { get; }

    public CategoryRepository(DatabaseContext context, IMapper mapper) : base(context)
    {
        Mapper = mapper;
    }

    public async Task DeleteAsync(int id)
    {
        var category = await Context.Categories.FirstAsync(x => x.Id == id);

        Context.Remove(category);
        await Context.SaveChangesAsync();
    }

    public async Task<CategoryResponse> CreateCategoryAsync(CategoryCreateRequest categoryCreateRequest)
    {
        var category = Mapper.Map<Category>(categoryCreateRequest);

        await Context.AddAsync(category);
        await Context.SaveChangesAsync();

        return Mapper.Map<CategoryResponse>(category);
    }

    public async Task<CategoryResponse> UpdateCategoryAsync(CategoryUpdateRequest categoryCreateRequest)
    {
        var category = Mapper.Map<Category>(categoryCreateRequest);

        var entityEntry = await Context.AddAsync(category);
        entityEntry.State = EntityState.Modified;
        await Context.SaveChangesAsync();

        return Mapper.Map<CategoryResponse>(category);
    }

    public async Task<CategoryResponse> GetCategoryAsync(int id)
    {
        var category = await Context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        await Context.SaveChangesAsync();

        return category != null ? Mapper.Map<CategoryResponse>(category) : null;
    }

    public async Task<PagedResult<CategoryResponse>> GetCategories(PagedRequest<CategoryFiltersRequest> filtersRequest)
    {
        var categoriesQuery = FilterCategories(filtersRequest.Filters);
        var categoryResponsesQuery = from category in categoriesQuery select Mapper.Map<CategoryResponse>(category);

        return await categoryResponsesQuery.GetPaged(filtersRequest.Page, filtersRequest.PageSize);
    }

    private IQueryable<Category> FilterCategories(CategoryFiltersRequest categoryFiltersRequest)
    {
        var query = Context.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(categoryFiltersRequest.Description))
        {
            query = query.Where(x =>
                x.Description.ToLower().StartsWith(categoryFiltersRequest.Description.ToLower()));
        }

        if (!string.IsNullOrEmpty(categoryFiltersRequest.Name))
        {
            query = query.Where(x =>
                x.Name.ToLower().StartsWith(categoryFiltersRequest.Name.ToLower()));
        }

        if (categoryFiltersRequest.Id.HasValue)
        {
            query = query.Where(x => x.Id == categoryFiltersRequest.Id);
        }

        return query;
    }
}