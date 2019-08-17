using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolFinances.Contracts;
using SchoolFinances.Domain;

namespace SchoolFinances.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassesController : ControllerBase
	{
		private readonly IClassesRepository<SClass> _sClassesRepository;

		public ClassesController(IClassesRepository<SClass> sClassesRepository)
		{
			_sClassesRepository = sClassesRepository;
		}

		// POST api/values
		[HttpPost]
		public void Post(SClass value)
		{
			_sClassesRepository.CreateClass(
				new SClass {
					Username = User.Identity.Name,
					Description = value.Description
				});
		}

		[HttpGet]
		public IActionResult Get(string userName)
		{
			IEnumerable<SClass> sClasses = _sClassesRepository.GetClasses(userName);

			return Ok(sClasses);
		}
	}
}