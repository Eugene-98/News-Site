using Microsoft.AspNetCore.Http;
using React.AspNet;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using News_Site.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Online_storeContext")));

builder.Services.AddControllersWithViews()
	.AddNewtonsoftJson(options =>
		options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
	);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = new Microsoft.AspNetCore.Http.PathString ("/Account/login");
		options.AccessDeniedPath = new PathString("/Account/Login");
	});


builder.Services.AddAuthorization();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddReact();

builder.Services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
	.AddChakraCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");

	app.UseHsts();
}

app.UseReact(config =>
{
	config
		.AddScript("~/js/index.jsx")
		.AddScript("~/js/remarkable.min.js");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
