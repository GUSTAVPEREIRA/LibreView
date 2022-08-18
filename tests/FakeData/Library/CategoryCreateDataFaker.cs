using Bogus;
using Core.Library.Models;

namespace FakeData.Library;

public sealed class CategoryCreateDataFaker : Faker<CategoryCreateRequest>
{
    public CategoryCreateDataFaker()
    {
        RuleFor(x => x.Description, x => x.Lorem.Letter(500));
        RuleFor(x => x.Name, x => x.Lorem.Letter(100));
    }
}