using ChoreTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<List<Icon>> GetIcons()
        {
            var data = DataAccess.GetIcons();
            return Ok(data);
        }

        [HttpGet("{ID}")]
        public ActionResult<Icon> GetIcon(int ID)
        {
            var data = DataAccess.GetIcon(ID);
            return Ok(data);
        }
    }
}
