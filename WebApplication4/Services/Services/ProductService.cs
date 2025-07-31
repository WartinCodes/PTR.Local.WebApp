using WebApplication4.Models.Dtos.Requests;
using WebApplication4.Models.Dtos.Responses;
using WebApplication4.Services.Implementations;

namespace WebApplication4.Services.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<ProductResponseDto> _productos = new();
        private static int _id = 1;

        public async Task<ProductResponseDto> CreateAsync(ProductRequestDto dto)
        {
            var nuevoProducto = new ProductResponseDto
            {
                Id = _id++,
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                Quantity = dto.Quantity
            };

            _productos.Add(nuevoProducto);
            return await Task.FromResult(nuevoProducto);
        }

        public async Task<ProductResponseDto?> GetByIdAsync(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(producto);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
        {
            return await Task.FromResult(_productos);
        }

        public async Task<ProductResponseDto?> UpdateAsync(int id, ProductRequestDto dto)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return null;

            producto.Name = dto.Name;
            producto.Price = dto.Price;
            producto.Category = dto.Category;
            producto.Quantity = dto.Quantity;

            return await Task.FromResult(producto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return false;

            _productos.Remove(producto);
            return await Task.FromResult(true);
        }
    }
}