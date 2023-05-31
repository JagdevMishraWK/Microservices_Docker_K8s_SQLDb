using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopping.API.Models;
using Shopping.API.ShoppingContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _ProductDbContext;

        public ProductController(ProductDbContext ProductDbContext)
        {
            _ProductDbContext = ProductDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _ProductDbContext.Products;
        }

        [HttpGet("{ProductId:int}")]
        public async Task<ActionResult<Product>> GetById(int ProductId)
        {
            var Product = await _ProductDbContext.Products.FindAsync(ProductId);
            return Product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product Product)
        {
            await _ProductDbContext.Products.AddAsync(Product);
            await _ProductDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product Product)
        {
            _ProductDbContext.Products.Update(Product);
            await _ProductDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{ProductId:int}")]
        public async Task<ActionResult> Delete(int ProductId)
        {
            var Product = await _ProductDbContext.Products.FindAsync(ProductId);
            _ProductDbContext.Products.Remove(Product);
            await _ProductDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
