using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult get()
            
        {
            return Ok("Hey people!");
                
        }
        [HttpPost]
        public IActionResult post(JObject payload) 
        {
            return Ok(payload);
        }

    }
}
