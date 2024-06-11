using AMS3A.Sales.API.Domain;
using AMS3A.Sales.Context;
using AMS3A.Sales.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS3A.Sales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public ProductController(ApplicationDataContext applicationDataContext)
        {
            _context = applicationDataContext;
        }
        [HttpPost]
        public IActionResult Post(ProductRequest productRequest)
        {
            var product = new Product()
            {
                Description = productRequest.Description,
                Stock = productRequest.Stock,
                Price = productRequest.Price,
                ImageURL = productRequest.ImageURL,
                CategoryId = productRequest.CategoryId
            };

            product.Id = Guid.NewGuid();
            if (product == null) return NotFound();
            _context.Product.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Product.ToList();
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetById(Guid Id)
        {
            var product = _context.Product.Where(x => x.Id == Id).FirstOrDefault();
            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
