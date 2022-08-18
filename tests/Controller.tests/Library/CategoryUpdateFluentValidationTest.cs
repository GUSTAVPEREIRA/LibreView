using Api.Library;
using Bogus;
using FakeData.Library;
using FluentValidation.TestHelper;

namespace Controller.tests.Library;

public class CategoryUpdateFluentValidationTest
{
    private readonly CategoryUpdateValidation _categoryUpdateValidation;

    public CategoryUpdateFluentValidationTest()
    {
        _categoryUpdateValidation = new CategoryUpdateValidation();
    }

    [Fact]
    public void ShouldNotHaveErrorWhenNameLengthIsLessHundredOrGreaterThan5()
    {
        var name = new Faker().Random.String(5, 100);
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Name = name;

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldNotHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ShouldNotHaveErrorWhenDescriptionLengthIsLessFiveHundredOrGreaterThan5()
    {
        var description = new Faker().Random.String(5, 500);
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Description = description;

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }

    [Fact]
    public void ShouldNotHaveErrorWhenDescriptionIsNull()
    {
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Description = null;

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldNotHaveValidationErrorFor(x => x.Description);
    }
    
    [Fact]
    public void ShouldNotHaveErrorWhenIdIsGreaterThan0()
    {
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldNotHaveValidationErrorFor(x => x.Id);
    }
    
    [Fact]
    public void ShouldHaveErrorWhenIdIsLessThan0()
    {
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Id = new Faker().Random.Int(-100, -1);

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldHaveValidationErrorFor(x => x.Id);
    }

    [Theory]
    [InlineData(1, 4)]
    [InlineData(101, 102)]
    public void ShouldHaveErrorWhenNameLengthIsLessFiveOrGreaterThan100(int start, int end)
    {
        var name = new Faker().Random.String(start, end);
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Name = name;

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Theory]
    [InlineData(1, 4)]
    [InlineData(501, 502)]
    public void ShouldHaveErrorWhenDescriptionLengthIsLessFiveOrGreaterThanFiveHundred(int start, int end)
    {
        var description = new Faker().Random.String(start, end);
        var categoryUpdate = new CategoryUpdateDataFaker().Generate();
        categoryUpdate.Description = description;

        var result = _categoryUpdateValidation.TestValidate(categoryUpdate);

        result.ShouldHaveValidationErrorFor(x => x.Description);
    }
}