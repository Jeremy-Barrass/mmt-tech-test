using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Models;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeaturedProductsController : ControllerBase
    {
        private readonly ILogger<FeaturedProductsController> _logger;

        public FeaturedProductsController(ILogger<FeaturedProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get() => new List<Product>();

        [HttpGet]
        public IEnumerable<string> Categories() => new List<string>();

        [HttpGet]
        public IEnumerable<Product> Get(string category) => new List<Product>();
    }
}