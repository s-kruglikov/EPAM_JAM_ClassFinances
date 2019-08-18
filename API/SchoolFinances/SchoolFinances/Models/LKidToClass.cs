namespace SchoolFinances.Models
{
	public partial class LKidToClass
	{
		public int Id { get; set; }

		public int KidId { get; set; }

		public int ClassId { get; set; }

		public bool Active { get; set; }

		public virtual Classe Class { get; set; }

		public virtual Kid Kid { get; set; }
	}
}
