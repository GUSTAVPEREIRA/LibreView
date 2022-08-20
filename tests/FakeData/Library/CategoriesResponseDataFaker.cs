using Bogus;
using Core.Library.Models;

namespace FakeData.Library;

public sealed class CategoriesResponseDataFaker : Faker<CategoryResponse>
{
    public CategoriesResponseDataFaker()
    {
        RuleFor(x => x.Description, x => x.Random.String(5, 500));
        RuleFor(x => x.Name, x => x.Random.String(5, 100));
        RuleFor(x => x.Id, x => x.Random.Int());
    }
}