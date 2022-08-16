using Core.Library.Models;
using FluentValidation;

namespace Api.Library;

public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateRequest>
{
    public CategoryUpdateValidation()
    {
        RuleFor(x => x.Id).NotNull().Must(x => x > 0);
        RuleFor(x => x.Description).Null().MaximumLength(500).MinimumLength(5);
        RuleFor(x => x.Name).NotNull().MaximumLength(100).MinimumLength(5);
    }
}