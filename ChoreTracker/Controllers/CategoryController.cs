using ChoreTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<List<Category>> GetCategories()
        {
            var data = DataAccess.GetCategories();
            return Ok(data);
        }
    }
}
