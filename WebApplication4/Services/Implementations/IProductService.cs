using WebApplication4.Models.Dtos.Requests;
using WebApplication4.Models.Dtos.Responses;

namespace WebApplication4.Services.Implementations
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync();
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<ProductResponseDto> CreateAsync(ProductRequestDto dto);
        Task<ProductResponseDto?> UpdateAsync(int id, ProductRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}