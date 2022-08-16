using Core.Library;
using Core.Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Library;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CategoryResponse>> CreateCategoryAsync(CategoryCreateRequest createRequest)
    {
        var categoryResponse = await _categoryService.CreateCategoryAsync(createRequest);

        return CreatedAtAction(nameof(GetCategory), new { id = categoryResponse.Id }, categoryResponse);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("{id:int}")]
    public async Task<ActionResult<CategoryResponse>> GetCategory(int id)
    {
        var categoryResponse = await _categoryService.GetCategoryAsync(id);

        if (categoryResponse == null)
        {
            return NotFound();
        }

        return Ok(categoryResponse);
    }
}