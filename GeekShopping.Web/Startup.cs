using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace GeekShopping.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//config de injecao para o HttpClient
			services.AddHttpClient<IProductService, ProductService>(c =>
					c.BaseAddress = new Uri(Configuration["ServiceUrls:ProductAPI"]));

			services.AddHttpClient<ICartService, CartService>(c =>
					c.BaseAddress = new Uri(Configuration["ServiceUrls:CartAPI"]));

			services.AddHttpClient<ICouponService, CouponService>(c =>
					c.BaseAddress = new Uri(Configuration["ServiceUrls:CouponAPI"]));


			//config de autenticacao

			services.AddAuthentication(options => 
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				.AddCookie("Cookies", c=> c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
				.AddOpenIdConnect("oidc", options =>
				{
					options.Authority = Configuration["ServiceUrls:IdentityServer"];
					options.GetClaimsFromUserInfoEndpoint = true;
					options.ClientId = "geek_shopping";
					options.ClientSecret = "my_super_secret";
					options.ResponseType = "code";
					options.ClaimActions.MapJsonKey("role", "role", "role");
					options.ClaimActions.MapJsonKey("sub", "sub", "sub");
					options.TokenValidationParameters.NameClaimType = "name";
					options.TokenValidationParameters.RoleClaimType = "role";
					options.Scope.Add("geek_shopping");
					options.SaveTokens = true;
				});

			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
