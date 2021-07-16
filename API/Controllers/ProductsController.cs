using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specifications;
using AutoMapper;
using API.Dtos;
using Microsoft.AspNetCore.Http;
using API.Errors;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAllWithSpecificationAsync(spec)
                                              .ConfigureAwait(false);
            var productDtos = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetByIdWithSpecificationAsync(spec)
                                         .ConfigureAwait(false);

            if (product == null) return NotFound(new ApiResponse(404));

            var productDto = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productDto);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrandRepo.ListAllAsync()
                                                .ConfigureAwait(false);
            return base.Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var brands = await _productTypeRepo.ListAllAsync()
                                               .ConfigureAwait(false);
            return base.Ok(brands);
        }
    }
}
