using Microsoft.EntityFrameworkCore;

namespace SchoolFinances.Models
{
	public partial class ApplicationContext : DbContext
	{
		public ApplicationContext()
		{
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Classe> Classes { get; set; }

		public virtual DbSet<Kid> Kids { get; set; }

		public virtual DbSet<LKidToClass> LKidToClass { get; set; }

		public virtual DbSet<LUserToClass> LUserToClass { get; set; }

		public virtual DbSet<LUserToKid> LUserToKid { get; set; }

		public virtual DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlServer("Server=tcp:epamjamschoolfinances.database.windows.net,1433;Initial Catalog=epamjamschoolfinances;Persist Security Info=False;User ID=adminjam;Password=Epamjam2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

			modelBuilder.Entity<Classe>(entity =>
			{
				entity.HasKey(e => e.ClassId)
					.HasName("PK__classes__FDF4798688A77687");

				entity.ToTable("classes");

				entity.Property(e => e.ClassId).HasColumnName("class_id");

				entity.Property(e => e.ClassName)
					.IsRequired()
					.HasColumnName("class_name");
			});

			modelBuilder.Entity<Kid>(entity =>
			{
				entity.HasKey(e => e.KidId)
					.HasName("PK__kids__F163BDD8B7ED6DB1");

				entity.ToTable("kids");

				entity.Property(e => e.KidId).HasColumnName("kid_id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasColumnName("first_name");

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasColumnName("last_name");
			});

			modelBuilder.Entity<LKidToClass>(entity =>
			{
				entity.ToTable("l_kid_to_class");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.ClassId).HasColumnName("class_id");

				entity.Property(e => e.KidId).HasColumnName("kid_id");

				entity.HasOne(d => d.Class)
					.WithMany(p => p.LKidToClass)
					.HasForeignKey(d => d.ClassId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_kid_to_class_ToClasses");

				entity.HasOne(d => d.Kid)
					.WithMany(p => p.LKidToClass)
					.HasForeignKey(d => d.KidId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_kid_to_class_ToKids");
			});

			modelBuilder.Entity<LUserToClass>(entity =>
			{
				entity.ToTable("l_user_to_class");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.ClassId).HasColumnName("class_id");

				entity.Property(e => e.Role)
					.IsRequired()
					.HasColumnName("role");

				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.Class)
					.WithMany(p => p.LUserToClass)
					.HasForeignKey(d => d.ClassId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_user_to_class_ToClasses");

				entity.HasOne(d => d.User)
					.WithMany(p => p.LUserToClass)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_user_to_class_ToUsers");
			});

			modelBuilder.Entity<LUserToKid>(entity =>
			{
				entity.ToTable("l_user_to_kid");

				entity.Property(e => e.Id).HasColumnName("id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.KidId).HasColumnName("kid_id");

				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.HasOne(d => d.Kid)
					.WithMany(p => p.LUserToKid)
					.HasForeignKey(d => d.KidId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_user_to_kid_ToKids");

				entity.HasOne(d => d.User)
					.WithMany(p => p.LUserToKid)
					.HasForeignKey(d => d.UserId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_l_user_to_kid_ToUsers");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.UserId)
					.HasName("PK__users__B9BE370F8DD5FBB6");

				entity.ToTable("users");

				entity.Property(e => e.UserId).HasColumnName("user_id");

				entity.Property(e => e.Active).HasColumnName("active");

				entity.Property(e => e.FirstName)
					.IsRequired()
					.HasColumnName("first_name");

				entity.Property(e => e.LastName)
					.IsRequired()
					.HasColumnName("last_name");

				entity.Property(e => e.Password)
					.IsRequired()
					.HasColumnName("password");

				entity.Property(e => e.PhoneNumber)
					.IsRequired()
					.HasColumnName("phone_number");

				entity.Property(e => e.Role)
					.IsRequired()
					.HasColumnName("role")
					.HasDefaultValueSql("(user_name())");

				entity.Property(e => e.UserName)
					.IsRequired()
					.HasColumnName("user_name");
			});
		}
	}
}
