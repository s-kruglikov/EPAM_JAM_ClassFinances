using System;
using System.Collections.Generic;

namespace SchoolFinances.Models
{
	public partial class Kid
	{
		public Kid()
		{
			LKidToClass = new HashSet<LKidToClass>();
			LUserToKid = new HashSet<LUserToKid>();
		}

		public int KidId { get; set; }

		public string LastName { get; set; }

		public string FirstName { get; set; }

		public bool Active { get; set; }

		public virtual ICollection<LKidToClass> LKidToClass { get; set; }

		public virtual ICollection<LUserToKid> LUserToKid { get; set; }
	}
}
