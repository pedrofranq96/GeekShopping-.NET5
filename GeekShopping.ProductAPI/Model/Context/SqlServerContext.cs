using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
	public class SqlServerContext : DbContext
	{
		public SqlServerContext() {}
		public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Product>()
			   .Property(p => p.Price).HasColumnType("decimal(38,02)").IsRequired();
		}
	}
}
