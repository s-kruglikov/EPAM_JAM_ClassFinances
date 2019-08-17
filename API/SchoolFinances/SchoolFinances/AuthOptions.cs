using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolFinances
{
	public class AuthOptions
	{
		public const string ISSUER = "SchoolFinanceServer"; // издатель токена

		public const string AUDIENCE = "http://localhost:8080/";

		const string KEY = "mysupersecret_secretkey!123";	// encryption key

		public const int LIFETIME = 1; // token lifetime

		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
		}
	}
}
