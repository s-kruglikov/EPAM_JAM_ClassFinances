using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolFinances.Domain
{
	[Table("Classes", Schema = "dbo")]
	public class SClass
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Username { get; set; }
	}
}
