using AutoMapper;
using Core.Library;
using Core.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Library;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    private IMapper Mapper { get; set; }

    public CategoryRepository(DatabaseContext context, IMapper mapper) : base(context)
    {
        Mapper = mapper;
    }

    public async Task Delete(int id)
    {
        var category = Context.Categories.First(x => x.Id == id);

        Context.Remove(category);
        await Context.SaveChangesAsync();
    }

    public async Task<CategoryResponse> CreateCategory(CategoryCreateRequest categoryCreateRequest)
    {
        var category = Mapper.Map<Category>(categoryCreateRequest);

        await Context.AddAsync(category);
        await Context.SaveChangesAsync();

        return Mapper.Map<CategoryResponse>(category);
    }

    public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest categoryCreateRequest)
    {
        var category = Mapper.Map<Category>(categoryCreateRequest);

        var entityEntry = await Context.AddAsync(category);
        entityEntry.State = EntityState.Modified;
        await Context.SaveChangesAsync();

        return Mapper.Map<CategoryResponse>(category);
    }
}