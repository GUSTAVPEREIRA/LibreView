using Core.Library;
using Core.Library.Models;
using Core.Pagination;
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
    public async Task<ActionResult> CreateCategoryAsync(CategoryCreateRequest createRequest)
    {
        var categoryResponse = await _categoryService.CreateCategoryAsync(createRequest);

        return CreatedAtAction(nameof(GetCategory), new { id = categoryResponse.Id }, categoryResponse);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateCategoryAsync(CategoryUpdateRequest updateRequest)
    {
        var categoryResponse = await _categoryService.UpdateCategoryAsync(updateRequest);

        return Ok(categoryResponse);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("{id:int}")]
    public async Task<ActionResult> GetCategory(int id)
    {
        var categoryResponse = await _categoryService.GetCategoryAsync(id);

        if (categoryResponse == null)
        {
            return NotFound();
        }

        return Ok(categoryResponse);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResult<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("pagination")]
    public async Task<ActionResult> GetCategoriesByFilters(
        [FromQuery] PagedRequest<CategoryFiltersRequest> pagedRequest)
    {
        var categoryResponse = await _categoryService.GetCategoriesByFilters(pagedRequest);

        return Ok(categoryResponse);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("delete/{id:int}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);

        return NoContent();
    }
}