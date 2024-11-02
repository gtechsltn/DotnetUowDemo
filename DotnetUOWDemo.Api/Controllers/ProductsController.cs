using AutoMapper;
using DotnetUOWDemo.Api.Models;
using DotnetUOWDemo.Api.Models.DTOs;
using DotnetUOWDemo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetUOWDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ILogger<ProductsController> _logger;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, ILogger<ProductsController> logger, IMapper mapper)
    {
        _productService = productService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductCreateDto productToAdd)
    {
        try
        {
            var product = _mapper.Map<Product>(productToAdd);
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(AddProduct), product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto productToUpdate)
    {
        try
        {
            if (id != productToUpdate.Id)
            {
                return BadRequest("Product ID mismatch");
            }
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound("Product not found");
            }
            var product = _mapper.Map<Product>(productToUpdate);
            await _productService.UpdateProductAsync(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            await _productService.DeleteProductAsync(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        try
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            var productToReturn = _mapper.Map<ProductDisplayDto>(product);
            return Ok(productToReturn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(string sTerm = "")
    {
        try
        {
            var products = await _productService.GetAllProductsAsync(sTerm);
            var productsToReturn = products.Select(p => new ProductDisplayDto
            {
                Id = p.Id,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name
            });
            return Ok(productsToReturn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}

