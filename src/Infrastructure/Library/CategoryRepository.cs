using AutoMapper;
using Core.Library;
using Core.Library.Models;
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
}