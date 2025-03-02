using ChoreTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<List<Chore>> GetChores()
        {
            var data = DataAccess.GetChores();
            return Ok(data);
        }
    }
}
