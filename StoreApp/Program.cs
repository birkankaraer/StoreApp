using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); //controller olmadan da razor pageleri kullanabilecek servisi uygulamaya dahil ettik

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession(); //session kullanabilmek icin

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name: "Admin",
		areaName: "Admin",
		pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
	);

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}"
	);

	// Hata kontrol middleware'i eklendi
	endpoints.MapControllerRoute(
		name: "error",
		pattern: "error/{code}",
		new { controller = "Error", action = "Index" }
	);

	endpoints.MapRazorPages();
});
app.ConfigureandCheckMigration();
app.ConfigureLocalization();

app.UseExceptionHandler("/error/500");
app.UseStatusCodePagesWithReExecute("/error/{0}");

app.Run();

