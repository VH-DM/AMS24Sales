using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AMS3A.Sales.Domain;
using AMS3A.Sales.API.Domain;
using AMS3A.Sales.Context;
namespace AMS3A.Sales.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDataContext _context;
        public CategoryController(ApplicationDataContext applicationDataContext)
        {
            _context = applicationDataContext;
        }
        [HttpPost]
        public ActionResult Post(CategoryRequest categoryRequest)
        {
            var cat = new Category()
            {
                Description = categoryRequest.Description,
                IsActived = true,
                ImageURL = categoryRequest.ImageURL,
            };
            if (cat == null) return NotFound();
            _context.Category.Add(cat);
            _context.SaveChanges();
            return Ok(cat);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _context.Category.ToList();
        }
        [HttpGet]
        [Route("{Id:Guid}")]
        public ActionResult<Category> GetById(Guid Id)
        {
            var cat = _context.Category.FirstOrDefault(x => x.Id == Id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
    }
}
