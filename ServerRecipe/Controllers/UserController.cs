using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngularServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //static List<User> Users = new List<User>();
       static List<User> Users = new List<User>
{
    new User { Code = 1, Name = "David", Address = "321 Pine St", Email = "david@example.com", Password = "mypassword1" },
    new User { Code = 2, Name = "Eve", Address = "654 Birch St", Email = "eve@example.com", Password = "mypassword2" },
    new User { Code = 3, Name = "Frank", Address = "987 Maple St", Email = "frank@example.com", Password = "mypassword3" },
    new User { Code = 4, Name = "Grace", Address = "135 Walnut St", Email = "grace@example.com", Password = "mypassword4" }
};

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = Users.Find(u => u.Code == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            Users.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Code }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            var exixtingUser = Users.Find(u => u.Code == id);
            if (exixtingUser == null)
            {
                return NotFound();
            }
            Users[Users.IndexOf(exixtingUser)] = user;
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = Users.Find(u => u.Code == id);
            if (user == null)
            {
                return NotFound();
            }
            Users.Remove(user);
            return NoContent();
        }
    }
}
