using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models.Dtos.Requests;
using WebApplication4.Models.Dtos.Responses;
using WebApplication4.Services.Implementations;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductRequestDto> _validator;

        public ProductController(IProductService productService, IValidator<ProductRequestDto> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        // GET /api/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ProductResponseDto> products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // GET /api/product/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDto>> Get([FromRoute] int id)
        {
            ProductResponseDto? product = await _productService.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST /api/product
        [HttpPost]
        public async Task<ActionResult<ProductResponseDto>> Post([FromBody] ProductRequestDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            ProductResponseDto product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT /api/product/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponseDto>> Put([FromRoute] int id, [FromBody] ProductRequestDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var updated = await _productService.UpdateAsync(id, dto);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE /api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
