using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitenancy.Dtos;

namespace Multitenancy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductsAsync(cancellationToken));
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProduct(int productId , CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductAsync(productId, cancellationToken);

            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateProduct(CreateProductDto productDto, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Rate = productDto.Rate
            };

            var createdProduct = await _productService.CreateProductAsync(product);

            return Ok(createdProduct);
        }
    }
}
