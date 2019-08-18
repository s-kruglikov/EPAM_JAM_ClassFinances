using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SchoolFinances.Abstract;

using SchoolFinances.Models;

namespace SchoolFinances.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassesController : ControllerBase
	{
		private readonly IClassRepository<Classe> _classeRepository;

		public ClassesController(IClassRepository<Classe> classeRepository)
		{
			_classeRepository = classeRepository;
		}

		// POST api/classes/create
		[Authorize]
		[HttpPost]
		[Route("create")]
		public int Create([FromBody] JObject value)
		{
			return _classeRepository.CreateClass(
				value["description"].ToString(),
				value["userId"].ToObject<int>()
			);
		}

		// GET api/classes
		[Authorize]
		[HttpGet]
		public IActionResult Get(int userId)
		{
			IEnumerable<Classe> classes = _classeRepository.GetClasses(userId);

			return Ok(classes);
		}
	}
}