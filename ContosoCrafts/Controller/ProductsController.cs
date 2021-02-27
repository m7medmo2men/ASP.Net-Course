using System.Collections.Generic;
using ContosoCrafts.Models;
using ContosoCrafts.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get;  }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpGet]
        [Route("Rate")]
        public ActionResult Get([FromQuery] string id, [FromQuery] int rating)
        {
            ProductService.AddRating(id, rating);
            return Ok();
        }
    }
}