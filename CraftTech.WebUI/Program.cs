using CraftTech.DataAccessLayer.Concrete;
using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace CraftTech.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Login/"; // Login sayfası
                options.AccessDeniedPath = "/Login/Login/"; // Yetkisiz erişim
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
                options.SlidingExpiration = true;
                options.Cookie.SameSite = SameSiteMode.None; // Cookie tüm alan adlarına gönderilebilir
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS üzerinden iletilir

            });
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";  // Login sayfasý
        options.AccessDeniedPath = "/Login/Login";
        options.LogoutPath = "/Login/Logout"; // Logout iþlemi
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Oturum süresi
        options.SlidingExpiration = true;
    });

            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://api.craftechmuhendislik.com/api/");
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAuthenticatedUser", policy => policy.RequireAuthenticatedUser());
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Message}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
