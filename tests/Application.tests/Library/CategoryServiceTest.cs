using Application.Library;
using Bogus;
using Core.Library;
using Core.Library.Models;
using Core.Pagination;
using FakeData.Library;
using FluentAssertions;
using Moq;

namespace Application.tests.Library;

public class CategoryServiceTest
{
    private readonly Mock<ICategoryRepository> _mockCategoryRepository;
    private readonly CategoryService _categoryService;

    public CategoryServiceTest()
    {
        _mockCategoryRepository = new Mock<ICategoryRepository>();
        _categoryService = new CategoryService(_mockCategoryRepository.Object);
    }

    [Fact]
    public async Task CreateCategoryAsyncOk()
    {
        var categoryCreateRequest = new CategoryCreateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryCreateRequest);

        _mockCategoryRepository.Setup(x => x.CreateCategoryAsync(It.IsAny<CategoryCreateRequest>()))
            .ReturnsAsync(categoryResponse);

        var result = await _categoryService.CreateCategoryAsync(categoryCreateRequest);

        result.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryRepository.Verify(x => x.CreateCategoryAsync(It.IsAny<CategoryCreateRequest>()), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsyncOk()
    {
        var categoryUpdateRequest = new CategoryUpdateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryUpdateRequest);

        _mockCategoryRepository.Setup(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>()))
            .ReturnsAsync(categoryResponse);

        var result = await _categoryService.UpdateCategoryAsync(categoryUpdateRequest);

        result.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryRepository.Verify(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetCategoryAsyncOk()
    {
        var categoryUpdateRequest = new CategoryUpdateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryUpdateRequest);

        _mockCategoryRepository.Setup(x => x.GetCategoryAsync(It.IsAny<int>()))
            .ReturnsAsync(categoryResponse);

        var result = await _categoryService.GetCategoryAsync(new Random().Next(1, 99));

        result.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryRepository.Verify(x => x.GetCategoryAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task GetCategoryByFilterAsyncOk()
    {
        var categoryResponses = new CategoriesResponseDataFaker().Generate(new Random().Next(1, 100));
        var pagedResult = new PagedResult<CategoryResponse>
        {
            Results = categoryResponses,
            CurrentPage = 0,
            PageCount = categoryResponses.Count,
            PageSize = 5,
            RowCount = 5
        };

        _mockCategoryRepository.Setup(x => x.GetCategories(It.IsAny<PagedRequest<CategoryFiltersRequest>>()))
            .ReturnsAsync(pagedResult);

        var result = await _categoryService.GetCategoriesByFilters(new PagedRequest<CategoryFiltersRequest>
        {
            Page = 1,
            PageSize = 5
        });

        result.Should().BeEquivalentTo(pagedResult);
        _mockCategoryRepository.Verify(x => x.GetCategories(It.IsAny<PagedRequest<CategoryFiltersRequest>>()),
            Times.Once);
    }

    [Fact]
    public async Task DeleteCategoryAsyncOk()
    {
        _mockCategoryRepository.Setup(x => x.DeleteAsync(It.IsAny<int>()));

        await _categoryService.DeleteCategoryAsync(new Random().Next(1, 99));

        _mockCategoryRepository.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once);
    }

    private static CategoryResponse CreateCategoryResponse(CategoryCreateRequest request)
    {
        return new CategoryResponse
        {
            Description = request.Description,
            Name = request.Name,
            Id = new Faker().Random.Int(1, 99)
        };
    }
}