using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchoolFinances.Abstract;
using SchoolFinances.Models;

namespace SchoolFinances.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IUserRepository<User> _usersRepository;

		public AccountController(IUserRepository<User> usersRepository)
		{
			_usersRepository = usersRepository;
		}

		[HttpPost]
		[Route("register")]
		public async Task Register(User value)
		{
			// Check user existence
			// And perform other validations if needed.
			if (_usersRepository.GetUser(value.UserName) != null)
			{
				Response.StatusCode = 400;
				await Response.WriteAsync("Username is already exists.");
				return;
			}

			else
			{

				int id = _usersRepository.CreateUser(value);

				var encodedJwt = ProcessToken(value.UserName, "user");

				var response = new
				{
					accessToken = encodedJwt,
					userName = value.UserName,
					userId = id
				};

				// serialize response
				Response.ContentType = "application/json";
				await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				}));
			}
		}

		[HttpPost]
		[Route("login")]
		public async Task Login(User value)
		{
			var username = value.UserName;
			var password = value.Password;

			var identity = GetIdentity(username, password);
			if (identity == null)
			{
				Response.StatusCode = 400;
				await Response.WriteAsync("Invalid username or password.");
				return;
			}

			var encodedJwt = ProcessToken(username, identity.Claims.ToList()[1].Value);

			var response = new
			{
				accessToken = encodedJwt,
				userName = identity.Name,
				userId = _usersRepository.GetUser(identity.Name).UserId
			};

			// serialize response
			Response.ContentType = "application/json";
			await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
			{
				Formatting = Formatting.Indented
			}));
		}

		[Authorize]
		[Route("getUserInfo")]
		[HttpGet]
		public IActionResult GetUserInfo(int id)
		{
			var user = _usersRepository.GetUser(id);

			if (user != null)
			{
				var response = new
				{
					UserId = user.UserId,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Phonenumber = user.PhoneNumber
				};

				return Ok(JsonConvert.SerializeObject(response, new JsonSerializerSettings
				{
					Formatting = Formatting.Indented
				}));
			}

			else
				return BadRequest();
		}

		[Authorize(Roles = "admin")]
		[Route("updateUser")]
		[HttpPost]
		public IActionResult UpdateUser(User value)
		{
			//TO DO: Validate user before update
			int userid = _usersRepository.UpdateUser(value);

			return Ok(userid);
		}

		private ClaimsIdentity GetIdentity(string username, string password)
		{
			User person = _usersRepository.GetUser(username);
			if (person != null && person.Password == password)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserName),
					new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
				};
				ClaimsIdentity claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);
				return claimsIdentity;
			}

			// user not found
			return null;
		}

		private string ProcessToken(string userName, string role)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
			};

			ClaimsIdentity claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultRoleClaimType);

			var now = DateTime.UtcNow;
			// create JWT-token
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: claimsIdentity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}