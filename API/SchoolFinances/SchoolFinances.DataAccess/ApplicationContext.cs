using Microsoft.EntityFrameworkCore;
using SchoolFinances.Domain;
using System;

namespace SchoolFinances.DataAccess
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public ApplicationContext()
		{
			Database.EnsureCreated();
			Database.Migrate();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
		}
	}
}
