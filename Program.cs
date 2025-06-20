using Microsoft.AspNetCore.Authentication.Cookies;
using DualDashboardAuth.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) MVC
builder.Services.AddControllersWithViews();

// 2) Your user validator
builder.Services.AddSingleton<IUserService, InMemoryUserService>();

// 3) Cookie Authentication
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";  // fixed typo here
    });

// 4) (Optional) named policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
});

var app = builder.Build();

// 5) Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ORDER MATTERS
app.UseAuthentication();
app.UseAuthorization();

// 6) Default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

app.Run();
