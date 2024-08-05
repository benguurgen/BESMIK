
using BESMIK.SM.UserProfileViewComponent;
using BESMIK.SM.Validations;
using BESMIK.ViewModel.CompanyManager;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddHttpContextAccessor();


builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login"; // Kullan�c� oturum a�mam��sa bu sayfa ac�lacak
                options.AccessDeniedPath = "/Account/AccessDenied"; // Eri�im reddedildi�inde ac�lacak sayfa
            });

builder.Services.AddAuthorization();

builder.Services.AddHttpClient<UserProfileViewComponent>()
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler
        {
            UseCookies = false // MVC'nin oturum �erezlerini kullanmas�n� sa�lar
        };
        return handler;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); //session

app.UseRouting();

app.UseAuthentication(); // Kimlik do�rulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
