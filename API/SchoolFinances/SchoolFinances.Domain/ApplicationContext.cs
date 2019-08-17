using Microsoft.EntityFrameworkCore;
using SchoolFinances.Domain;
using System;

namespace SchoolFinances.Domain
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; }

		public DbSet<SClass> SClasses { get; set; }

		public ApplicationContext()
		{
			Database.EnsureCreated();
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			//Database.Migrate();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
		}
	}
}
