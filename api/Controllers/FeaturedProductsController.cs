using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.DbConnection;
using api.Models;
using api.Enums;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeaturedProductsController : ControllerBase
    {
        private readonly ILogger<FeaturedProductsController> _logger;
        private readonly AppDbContext _db;

        public FeaturedProductsController(AppDbContext db, ILogger<FeaturedProductsController> logger)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get() =>
            _db.Products.Where(p => p.Sku < 40000).ToList();

        [HttpGet]
        [Route("[controller]/[action]")]
        public IEnumerable<string> Categories() => 
            _db.Categories.Select(c => c.Name).ToList();

        [HttpGet]
        [Route("[controller]/{category}")]
        public IEnumerable<Product> Get(string category)
        {
            var catValue = Enum.Parse<ProdCategory>(category);
            return _db.Products.Where(p => p.Category == catValue);
        }
    }
}