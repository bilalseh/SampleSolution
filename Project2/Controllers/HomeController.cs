using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Main Get Api");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:44362/api/values/" + id);
            return Ok(response.Content.ReadAsStringAsync().Result);
        }
    }
}
