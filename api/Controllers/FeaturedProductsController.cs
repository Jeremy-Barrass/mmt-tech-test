using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Interfaces;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeaturedProductsController : ControllerBase
    {
        private readonly ILogger<FeaturedProductsController> _logger;
        private readonly IAppDbContext _db;

        public FeaturedProductsController(IAppDbContext db, ILogger<FeaturedProductsController> logger)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get() =>
            _db.Products.Where(p => p.Sku < 40000).ToList();

        [HttpGet]
        [Route("[controller]/[action]")]
        public IEnumerable<string> Categories() => new List<string>();

        [HttpGet]
        [Route("[controller]/{category}")]
        public IEnumerable<Product> Get(string category) => new List<Product>();
    }
}