using Application.Abstraction.Models.OrderDtos;
using Application.Abstraction.Models.Product;

namespace Application.Abstraction.Services.Product
{
    public interface IProductServices
    {
        Task<ProductDto> AddProductAsync(CreateProductDto createdProductDto);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<UpdateProductDto> UpdateProductAsync(int productId, UpdateProductDto updateProductDto);
    }
}
