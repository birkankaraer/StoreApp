using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using Services;
using Entities.Models;
using StoreApp.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureDbContext(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
				b => b.MigrationsAssembly("StoreApp"));

				options.EnableSensitiveDataLogging(true); //bu satırı yazmamızın sebebi, veritabanı ile ilgili hataları görebilmek için. Proje yayına alınırken bu satırı silmeyi unutma.
			});
		}

		public static void ConfigureIdentity(this IServiceCollection services)
		{
			services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;//kullanıcıların mail adreslerini onaylamalarını istemiyoruz.
				options.User.RequireUniqueEmail = true;//aynı mail adresi ile birden fazla kullanıcı oluşturulmasını istemiyoruz.
				options.Password.RequireLowercase = false;//kullanıcıların şifrelerinde küçük harf kullanmalarını istemiyoruz.
				options.Password.RequireUppercase = false;//kullanıcıların şifrelerinde büyük harf kullanmalarını istemiyoruz.
				options.Password.RequireDigit = false;//kullanıcıların şifrelerinde rakam kullanmalarını istemiyoruz.
				options.Password.RequiredLength = 6;//kullanıcıların şifrelerinin en az 6 karakter olmasını istiyoruz.

			}).AddEntityFrameworkStores<RepositoryContext>();
		}

		public static void ConfigureSession(this IServiceCollection services)
		{
			services.AddDistributedMemoryCache(); //session kullanabilmek icin
			services.AddSession(options =>
			 {
				 options.Cookie.Name = "StoreApp.Session";
				 options.IdleTimeout = TimeSpan.FromMinutes(10);//session 10 dakika sonra sonlanacak, kullanıcı 10 dakika boyunca işlem yapmazsa session sonlanacak, kullanıcı tekrar giriş yapmak zorunda kalacak.
			 });
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(c => SessionCart.GetCart(c));
		}

		public static void ConfigureRepositoryRegistration(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}

		public static void ConfigureServiceRegistration(this IServiceCollection services)
		{
			services.AddScoped<IServiceManager, ServiceManager>();
			services.AddScoped<IProductService, ProductManager>();
			services.AddScoped<ICategoryService, CategoryManager>();
			services.AddScoped<IOrderService, OrderManager>();
		}

		public static void ConfigureRouting(this IServiceCollection services)
		{
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
				options.AppendTrailingSlash = false;//burada false yapmamızın sebebi, url'de / ile biten bir url'e istek geldiğinde, / ile biten bir url olmadığı için 404 hatası döndürüyor. Bu yüzden false yaparak / ile biten bir url'e istek geldiğinde, /'yi silerek isteği işleyecek.
			});
		}
	}
}
