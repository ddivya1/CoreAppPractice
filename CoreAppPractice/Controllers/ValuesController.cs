using CoreAppPractice.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAppPractice
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController() { }

        [HttpGet("Test")]
        public ActionResult GetNotFound()
        {
            throw new NotFoundException("Not FOund Error Display");
        }
    }
}
