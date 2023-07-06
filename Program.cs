using Microsoft.EntityFrameworkCore;
using SLVS;
using SLVS.Authentication.Manager;
using SLVS.Database.Repository.User;
using SLVS.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var cs = builder.Configuration.GetConnectionString("DefaultConnection") ??
         throw new InvalidOperationException("No connection string provided");

builder.Services.AddDbContext<SlvsContext>(optionsBuilder =>
{
    optionsBuilder.UseMySql(cs, ServerVersion.Parse("5.7.39"))
        .LogTo(Console.WriteLine, LogLevel.Warning);
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddFlashes();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.Name = ".SLVS_FRAMEWORK.Session";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.UseSession();

app.UseSlvsAuthentication();

app.Run();