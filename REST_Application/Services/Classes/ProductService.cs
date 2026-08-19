using AutoMapper;
using REST_Application.DTO;
using REST_Application.Models;
using REST_Application.Repository.Interfaces;
using REST_Application.Services.Interfaces;

namespace REST_Application.Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repository, IMapper mapper, ILogger<ProductService> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductResponseDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();

            return _mapper.Map<List<ProductResponseDto>>(products);
        }
        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            _logger.LogInformation("Getting product. ProductId: {ProductId}",
                id);

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning("Product not found. ProductId: {ProductId}",
                    id);

                return null;
            }

            _logger.LogInformation("Product found. ProductId: {ProductId}", id);

            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> CreateAsync(ProductCreateDto dto)
        {
            _logger.LogInformation("Creating product. ProductName: {ProductName}", dto.Name);

            var product = _mapper.Map<Product>(dto);

            var createdProduct = await _repository.AddAsync(product);

            _logger.LogInformation("Product created successfully. ProductId: {ProductId}",
                createdProduct.Id);

            return _mapper.Map<ProductResponseDto>(createdProduct);
        }

        public async Task<ProductResponseDto?> UpdateAsync(int id, ProductUpdateDto dto)
        {
            _logger.LogInformation("Updating product. ProductId: {ProductId}", id);

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning("Cannot update product because it was not found. ProductId: {ProductId}",
                    id);

                return null;
            }

            _mapper.Map(dto, product);

            await _repository.UpdateAsync(product);

            _logger.LogInformation("Product updated successfully. ProductId: {ProductId}",
                id);

            return _mapper.Map<ProductResponseDto>(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deleting product. ProductId: {ProductId}", id);

            var product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                _logger.LogWarning(
                    "Cannot delete product because it was not found. ProductId: {ProductId}",
                    id);

                return false;
            }

            await _repository.DeleteAsync(product);

            _logger.LogInformation("Product deleted successfully. ProductId: {ProductId}", id);

            return true;
        }
    }
}
