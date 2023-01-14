using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
	public class SqlServerContext : DbContext
	{
		
		public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

		public DbSet<Coupon> Coupons { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Coupon>()
			   .Property(p => p.DiscountAmount).HasColumnType("decimal(38,02)").IsRequired();

			builder.Entity<Coupon>().HasData(new Coupon
			{
				Id = 1,
				CouponCode = "GEEKS_2022_10",
				DiscountAmount = 10
			});
			builder.Entity<Coupon>().HasData(new Coupon
			{
				Id = 2,
				CouponCode = "GEEKS_2022_15",
				DiscountAmount = 15
			});
		}
	}
}