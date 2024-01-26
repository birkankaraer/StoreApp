using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
	public static class ApplicationExtensions
	{
		public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
		{
			RepositoryContext context = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<RepositoryContext>();
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
		}

		public static void ConfigureLocalization(this WebApplication app)
		{
			app.UseRequestLocalization(options =>
			{
				options.AddSupportedCultures("tr-TR")
				.AddSupportedCultures("tr-TR")
				.SetDefaultCulture("tr-TR");
			});
		}

		public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
		{
			const string adminUser = "Admin";
			const string adminPassword = "Admin+123456";

			UserManager<IdentityUser> userManager = app 
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<UserManager<IdentityUser>>();

			RoleManager<IdentityRole> roleManager = app
				.ApplicationServices
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<RoleManager<IdentityRole>>();

			IdentityUser user = await userManager.FindByNameAsync(adminUser); // Admin kullanıcısı var mı?
			if (user == null)
			{
				user = new IdentityUser()
				{
					Email = "birkan@birkan.com",
					PhoneNumber = "5554443322",
					UserName = adminUser,
				};

				var result = await userManager.CreateAsync(user, adminPassword); // Admin kullanıcısı yoksa oluşturulur.
				if (!result.Succeeded)
				{
					throw new Exception("Admin user could not created.");
				}
				var roleResult = await userManager.AddToRolesAsync(user, 
					roleManager
					.Roles
					.Select(r=>r.Name)
					.ToList()); // Admin kullanıcısı oluşturulduktan sonra Admin rolü atanır.
					
				if (!roleResult.Succeeded)
				{
					throw new Exception("System have problems with role defination for admin.");
				}
			
			}
		}
	}
}
