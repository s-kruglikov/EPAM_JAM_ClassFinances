using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFinances.Domain
{
	[Table("Users",Schema ="dbo")]
	public class User
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public string Password { get; set; }

		public string Role { get; set; }
	}
}
