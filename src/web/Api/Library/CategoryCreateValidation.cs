using Core.Library.Models;
using FluentValidation;

namespace Api.Library;

public class CategoryCreateValidation : AbstractValidator<CategoryCreateRequest>
{
    public CategoryCreateValidation()
    {
        RuleFor(x => x.Description).Null().MaximumLength(500).MinimumLength(5);
        RuleFor(x => x.Name).NotNull().MaximumLength(100).MinimumLength(5);
    }
}