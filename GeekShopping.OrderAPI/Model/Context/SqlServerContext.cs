using Microsoft.EntityFrameworkCore;

namespace GeekShopping.OrderAPI.Model.Base
{
	public class SqlServerContext : DbContext
	{

		public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

		public DbSet<OrderDetail> Details { get; set; }
		public DbSet<OrderHeader> Headers { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<OrderDetail>()
			   .Property(p => p.Price).HasColumnType("decimal(38,2)").IsRequired();

			builder.Entity<OrderHeader>()
			   .Property(d => d.DiscountTotal).HasColumnType("decimal(38,2)").IsRequired();

			builder.Entity<OrderHeader>()
			   .Property(p => p.PurchaseAmount).HasColumnType("decimal(38,2)").IsRequired();
		}
	}
}