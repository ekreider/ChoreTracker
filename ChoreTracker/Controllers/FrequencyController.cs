using ChoreTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<List<Frequency>> GetFrequencies()
        {
            var data = DataAccess.GetFrequencies();
            return Ok(data);
        }
    }
}
