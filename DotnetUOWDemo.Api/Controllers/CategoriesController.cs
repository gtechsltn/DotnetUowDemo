using AutoMapper;
using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.Models.DTOs;
using DotnetUOWDemo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetUOWDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger<CategoriesController> _logger;
    private readonly IMapper _mapper;

    public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger, IMapper mapper)
    {
        _categoryService = categoryService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryCreateDto categoryToAdd)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryToAdd);
            await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(AddCategory), category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateDto categoryToUpdate)
    {
        try
        {
            if (id != categoryToUpdate.Id)
            {
                return BadRequest("Category ID mismatch");
            }
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound("Category not found");
            }
            var category = _mapper.Map<Category>(categoryToUpdate);
            await _categoryService.UpdateCategoryAsync(category);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            await _categoryService.DeleteCategoryAsync(category);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            var categoryToReturn = _mapper.Map<CategoryDisplayDto>(category);
            return Ok(categoryToReturn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDisplayDto>>(categories);
            return Ok(categoriesToReturn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}

