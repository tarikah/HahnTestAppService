using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnTestAppService.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        [HttpGet("check")]
        public async Task<ActionResult> Health()
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
