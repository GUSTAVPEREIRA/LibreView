using Bogus;
using Core.Library.Models;

namespace FakeData.Library;

public sealed class CategoryUpdateDataFaker : Faker<CategoryUpdateRequest>
{
    public CategoryUpdateDataFaker()
    {
        RuleFor(x => x.Id, x => x.Random.Int(1, 999));
        RuleFor(x => x.Description, x => x.Lorem.Letter(500));
        RuleFor(x => x.Name, x => x.Lorem.Letter(100));
    }
}