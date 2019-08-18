using System.Collections.Generic;

namespace SchoolFinances.Models
{
	public partial class User
	{
		public User()
		{
			LUserToClass = new HashSet<LUserToClass>();
			LUserToKid = new HashSet<LUserToKid>();
		}

		public int UserId { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public string UserName { get; set; }

		public string Password { get; set; }

		public string PhoneNumber { get; set; }

		public string Role { get; set; }

		public bool Active { get; set; }

		public virtual ICollection<LUserToClass> LUserToClass { get; set; }

		public virtual ICollection<LUserToKid> LUserToKid { get; set; }
	}
}
