using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolFinances.Contracts;
using SchoolFinances.Domain;

namespace SchoolFinances.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
		private readonly IUsersRepository<User> _usersRepository;

		public ValuesController(IUsersRepository<User> usersRepository)
		{
			_usersRepository = usersRepository;
		}

		[HttpGet]
		[Route("GetAllUsers")]
		public IActionResult GetAllUsers()
		{
			IEnumerable<User> users = _usersRepository.GetAllUsers();
			return Ok(users);
		}

		// GET api/values
		[HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

		[Authorize]
		[Route("getlogin")]
		public IActionResult GetLogin()
		{
			return Ok($"Ваш логин: {User.Identity.Name}");
		}

		[Authorize(Roles = "admin")]
		[Route("getrole")]
		public IActionResult GetRole()
		{
			return Ok("Ваша роль: администратор");
		}
	}
}
