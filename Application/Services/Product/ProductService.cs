using Application.Abstraction.Models.Product;
using Application.Abstraction.Services.Product;
using AutoMapper;
using Domain.Entities.Products;
using Domain.Exceptions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence;

namespace Application.Services._Product
{
    public class ProductService : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> AddProductAsync(CreateProductDto createdProductDto)
        {
            var product = _mapper.Map<Product>(createdProductDto);
            await _unitOfWork.GetRepository<Product,int>().AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(productId);
            if (product is null) throw new NotFoundException($"Product with ID {productId} not found.");
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<UpdateProductDto> UpdateProductAsync(int productId, UpdateProductDto updateProductDto)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(productId);
            if (product is null) throw new NotFoundException($"Product with ID {productId} not found.");
            _mapper.Map(updateProductDto, product);
            _unitOfWork.GetRepository<Product, int>().Update(product);
            await _unitOfWork.CompleteAsync();
            return updateProductDto;
        }
    }
}
