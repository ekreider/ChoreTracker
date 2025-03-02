using ChoreTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyTypeController : ControllerBase
    {
        [HttpGet()]
        public ActionResult<List<FrequencyType>> GetFrequencyTypes()
        {
            var data = DataAccess.GetFrequencyTypes();
            return Ok(data);
        }

        [HttpGet("{ID}")]
        public ActionResult<FrequencyType> GetFrequency(int ID)
        {
            var data = DataAccess.GetFrequencyType(ID);
            return Ok(data);
        }
    }
}
