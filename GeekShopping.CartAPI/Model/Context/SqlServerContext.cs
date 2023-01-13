using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CartAPI.Model.Context
{
	public class SqlServerContext : DbContext
	{
		
		public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<CartDetail> CartDetailS { get; set; }
		public DbSet<CartHeader> CartHeaderS { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Product>()
			   .Property(p => p.Price).HasColumnType("decimal(6,2)").IsRequired();
		}
	}
}