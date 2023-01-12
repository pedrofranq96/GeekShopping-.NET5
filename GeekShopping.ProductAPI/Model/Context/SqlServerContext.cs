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

			builder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "Star Wars- Storm Tropper 2",
				Price = new decimal(89.90),
				Description = "Action Figure Star Wars, Storm Tropper Imperial",
				ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true",
				CategoryName = "Action Figure"
			});

			builder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Star Wars- Storm Tropper 3",
				Price = new decimal(99.90),
				Description = "Action Figure Star Wars, Storm Tropper Imperial",
				ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true",
				CategoryName = "Action Figure"
			});

			builder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Star Wars- Dart Vader",
				Price = new decimal(129.90),
				Description = "Action Figure Star Wars, General Sith",
				ImageURL = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/dot_net6_LTS/ShoppingImages/4_storm_tropper.jpg?raw=true",
				CategoryName = "Action Figure"
			});

		}
	}
}
