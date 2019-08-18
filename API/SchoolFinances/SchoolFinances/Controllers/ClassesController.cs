using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

		//		// POST api/values
		//		[Authorize]
		//		[HttpPost]
		//		public void Post(SClass value)
		//		{
		//			var username = User.Identity.Name;

		//			if(string.IsNullOrEmpty(username))
		//			{
		//				username = value.Username;
		//			}

		//			_sClassesRepository.CreateClass(
		//				new SClass {
		//					Username = username,
		//					Description = value.Description
		//				});
		//		}

		//		[Authorize]
		//		[HttpGet]
		//		public IActionResult Get(string userName)
		//		{
		//			IEnumerable<SClass> sClasses = _sClassesRepository.GetClasses(userName);

		//			return Ok(sClasses);
		//		}
	}
}