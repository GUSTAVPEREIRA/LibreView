using Api.Library;
using Bogus;
using Core.Library;
using Core.Library.Models;
using FakeData.Library;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Controller.tests.Library;

public class CategoryControllerTest
{
    private readonly CategoryController _categoryController;
    private readonly Mock<ICategoryService> _mockCategoryService;

    public CategoryControllerTest()
    {
        _mockCategoryService = new Mock<ICategoryService>();
        _categoryController = new CategoryController(_mockCategoryService.Object);
    }

    [Fact]
    public async Task CreateCategoryAsyncOk()
    {
        var categoryCreateRequest = new CategoryCreateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryCreateRequest);

        _mockCategoryService.Setup(x => x.CreateCategoryAsync(It.IsAny<CategoryCreateRequest>()))
            .Returns(Task.FromResult(categoryResponse));

        var response = (ObjectResult)await _categoryController.CreateCategoryAsync(categoryCreateRequest);

        response.StatusCode.Should().Be(StatusCodes.Status201Created);
        response.Value.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryService.Verify(x => x.CreateCategoryAsync(It.IsAny<CategoryCreateRequest>()), Times.Once);
    }

    [Fact]
    public async Task UpdateCategoryAsyncOk()
    {
        var categoryUpdateRequest = new CategoryUpdateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryUpdateRequest);

        _mockCategoryService.Setup(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>()))
            .Returns(Task.FromResult(categoryResponse));

        var response = (ObjectResult)await _categoryController.UpdateCategoryAsync(categoryUpdateRequest);

        response.StatusCode.Should().Be(StatusCodes.Status200OK);
        response.Value.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryService.Verify(x => x.UpdateCategoryAsync(It.IsAny<CategoryUpdateRequest>()), Times.Once);
    }

    [Fact]
    public async Task GetCategoryAsyncOk()
    {
        var categoryUpdateRequest = new CategoryUpdateDataFaker().Generate();
        var categoryResponse = CreateCategoryResponse(categoryUpdateRequest);

        _mockCategoryService.Setup(x => x.GetCategoryAsync(It.IsAny<int>()))
            .Returns(Task.FromResult(categoryResponse));

        var response = (ObjectResult)await _categoryController.GetCategory(categoryResponse.Id);

        response.StatusCode.Should().Be(StatusCodes.Status200OK);
        response.Value.Should().BeEquivalentTo(categoryResponse);
        _mockCategoryService.Verify(x => x.GetCategoryAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task GetCategoryAsyncNotFound()
    {
        _mockCategoryService.Setup(x => x.GetCategoryAsync(It.IsAny<int>()))
            .ReturnsAsync((CategoryResponse)null);

        var response = (StatusCodeResult)await _categoryController.GetCategory(1);

        response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        _mockCategoryService.Verify(x => x.GetCategoryAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task DeleteCategoryAsyncOk()
    {
        _mockCategoryService.Setup(x => x.DeleteCategoryAsync(It.IsAny<int>()));

        var response = (StatusCodeResult)await _categoryController.DeleteCategory(1);

        response.StatusCode.Should().Be(StatusCodes.Status204NoContent);
        _mockCategoryService.Verify(x => x.DeleteCategoryAsync(It.IsAny<int>()), Times.Once);
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