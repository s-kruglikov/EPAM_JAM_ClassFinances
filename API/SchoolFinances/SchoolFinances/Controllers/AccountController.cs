﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchoolFinances.Domain;

namespace SchoolFinances.Controllers
{
	//[Route("api/[controller]")]
	//[ApiController]
	public class AccountController : ControllerBase
	{
		private List<User> people = new List<User>
		{
			new User { Id = 1, Login="admin@gmail.com", Password="12345", Role = "admin", FirstName = "Homer", LastName = "Simpson" },
			new User { Id = 2, Login="qwerty", Password="55555", Role = "user", FirstName = "Bart", LastName = "Simpson" }
		};

		[HttpPost("/token")]
		public async Task Token()
		{
			var username = Request.Form["username"];
			var password = Request.Form["password"];

			var identity = GetIdentity(username, password);
			if (identity == null)
			{
				Response.StatusCode = 400;
				await Response.WriteAsync("Invalid username or password.");
				return;
			}

			var now = DateTime.UtcNow;
			// create JWT-token
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: identity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			var response = new
			{
				access_token = encodedJwt,
				username = identity.Name
			};

			// сериализация ответа
			Response.ContentType = "application/json";
			await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
		}

		private ClaimsIdentity GetIdentity(string username, string password)
		{
			User person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
			if (person != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
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
	}
}