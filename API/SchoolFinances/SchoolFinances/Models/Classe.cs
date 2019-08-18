using System.Collections.Generic;

namespace SchoolFinances.Models
{
	public partial class Classe
	{
		public Classe()
		{
			LKidToClass = new HashSet<LKidToClass>();
			LUserToClass = new HashSet<LUserToClass>();
		}

		public int ClassId { get; set; }

		public string ClassName { get; set; }

		public virtual ICollection<LKidToClass> LKidToClass { get; set; }

		public virtual ICollection<LUserToClass> LUserToClass { get; set; }
	}
}
