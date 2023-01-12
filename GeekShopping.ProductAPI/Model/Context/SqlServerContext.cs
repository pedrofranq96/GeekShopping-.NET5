using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
	public class SqlServerContext : DbContext
	{
		public SqlServerContext() {}
		public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }
	}
}
