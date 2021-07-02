using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> brandRepo, IGenericRepository<ProductType> typeRepo)
        {
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductMapSpecification();
            var result = await _productRepo.GetAllListWithSpecAsync(spec);
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductBrands()
        {
            var result = await _brandRepo.GetAllListAsync();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductTypes()
        {
            var result = await _typeRepo.GetAllListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var spec = new ProductMapSpecification(id);
            return await _productRepo.GetEntityWithSpec(spec);
        }
    }
}