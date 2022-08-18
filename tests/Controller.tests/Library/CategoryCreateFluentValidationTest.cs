using Api.Library;
using Bogus;
using FakeData.Library;
using FluentValidation.TestHelper;

namespace Controller.tests.Library;

public class CategoryCreateFluentValidationTest
{
    private readonly CategoryCreateValidation _categoryCreateValidation;

    public CategoryCreateFluentValidationTest()
    {
        _categoryCreateValidation = new CategoryCreateValidation();
    }

    [Fact]
    public void ShouldNotHaveErrorWhenNameLengthIsLessHundredOrGreaterThan5()
    {
        var name = new Faker().Random.String(5, 100);
        var createCategory = new CategoryCreateDataFaker().Generate();
        createCategory.Name = name;

        var result = _categoryCreateValidation.TestValidate(createCategory);

        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }
    
    [Fact]
    public void ShouldNotHaveErrorWhenDescriptionLengthIsLessFiveHundredOrGreaterThan5()
    {
        var description = new Faker().Random.String(5, 500);
        var createCategory = new CategoryCreateDataFaker().Generate();
        createCategory.Description = description;

        var result = _categoryCreateValidation.TestValidate(createCategory);

        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void ShouldNotHaveErrorWhenDescriptionIsNull()
    {
        var createCategory = new CategoryCreateDataFaker().Generate();
        createCategory.Description = null;

        var result = _categoryCreateValidation.TestValidate(createCategory);

        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Theory]
    [InlineData(1, 4)]
    [InlineData(101, 102)]
    public void ShouldHaveErrorWhenNameLengthIsLessFiveOrGreaterThan100(int start, int end)
    {
        var name = new Faker().Random.String(start, end);
        var createCategory = new CategoryCreateDataFaker().Generate();
        createCategory.Name = name;

        var result = _categoryCreateValidation.TestValidate(createCategory);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }
    
    [Theory]
    [InlineData(1, 4)]
    [InlineData(501, 502)]
    public void ShouldHaveErrorWhenDescriptionLengthIsLessFiveOrGreaterThanFiveHundred(int start, int end)
    {
        var description = new Faker().Random.String(start, end);
        var createCategory = new CategoryCreateDataFaker().Generate();
        createCategory.Description = description;

        var result = _categoryCreateValidation.TestValidate(createCategory);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}