using Microsoft.AspNetCore.Mvc;
using SerenUP.ApplicationCore.Entitiess;
using SerenUP.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SerenUP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {

        private readonly WatchService _watchService;
        // GET: api/<WatchController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = await _watchService.GetAllWatch();

            return Ok(res);
        }

        // GET api/<WatchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WatchController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WatchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WatchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
