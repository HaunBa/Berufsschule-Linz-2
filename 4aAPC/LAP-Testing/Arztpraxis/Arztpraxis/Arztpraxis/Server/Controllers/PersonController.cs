using Arztpraxis.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Arztpraxis.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public ApplicationDbContext Db { get; }

        public PersonController(ApplicationDbContext db)
        {
            Db = db;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(Db.Patienten.ToList());
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(Db.Patienten.FirstOrDefault(x => x.Id == id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Person value)
        {
            Db.Patienten.Add(value);
            Db.SaveChanges();
            return Ok();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var person = Db.Patienten.FirstOrDefault(x => x.Id == id);
            Db.Patienten.Remove(person);
            Db.SaveChanges();
        }
    }
}
