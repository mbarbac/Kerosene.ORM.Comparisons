using Kerosene.Tools;
using System;
using System.Data.Entity;

namespace Compare.EF.EagerMode
{
	// ==================================================== 
	public class EFContext : DbContext
	{
		/// <summary>
		/// Initializes the context so that it does not recreate the database.
		/// </summary>
		public static void InitializeTest()
		{
			if (_Initialized) return;

			Database.SetInitializer<EFContext>(null);
			_Initialized = true;
		}
		static bool _Initialized = false;

		/// <summary>
		/// Static initializator.
		/// </summary>
		static EFContext()
		{
			InitializeTest();
		}

		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public EFContext() : base("name=EFEntities") { }

		/// <summary>
		/// Creates the EF maps.
		/// </summary>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Region>().ToTable("Regions");
			modelBuilder.Entity<Region>().HasKey(x => x.Id);
			modelBuilder.Entity<Region>().Property(x => x.RowVersion).IsConcurrencyToken();

			modelBuilder.Entity<Country>().ToTable("Countries");
			modelBuilder.Entity<Country>().HasKey(x => x.Id);
			modelBuilder.Entity<Country>().Property(x => x.RowVersion).IsConcurrencyToken();

			modelBuilder.Entity<Employee>().ToTable("Employees");
			modelBuilder.Entity<Employee>().HasKey(x => x.Id);
			modelBuilder.Entity<Employee>().Property(x => x.RowVersion).IsConcurrencyToken();
		}

		public virtual DbSet<Region> Regions { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
	}
}
