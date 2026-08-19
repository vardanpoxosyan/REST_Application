using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_Application.DTO;
using REST_Application.Services.Interfaces;

namespace REST_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var product = await _service.CreateAsync(dto);

            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,ProductUpdateDto dto)
        {
            var product = await _service.UpdateAsync(id, dto);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
