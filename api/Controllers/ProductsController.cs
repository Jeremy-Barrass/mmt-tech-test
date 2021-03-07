using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.DbConnection;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("Products/Featured")]
        [Route("[controller]/[action]")]
        public IEnumerable<Product> Featured() =>
            _db.Products.Where(p => p.Sku < 40000).ToList();

        [HttpGet("Products/Categories")]
        [Route("[controller]/[action]")]
        public IEnumerable<string> Categories() => 
            _db.Categories.Select(c => c.Name).ToList();

        [HttpGet("Products/{category?}")]
        [Route("[controller]/{category?}")]
        public IEnumerable<Product> Get(string category = null)
        {
            if (category is null) return _db.Products.ToList();
            
            var value = _db.Categories.Where(c => c.Name == category).FirstOrDefault().Id;
            return _db.Products.Where(p => p.Category == value).ToList();
        }
    }
}