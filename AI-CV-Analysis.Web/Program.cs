using AI_CV_Analysis.Business.Interfaces;
using AI_CV_Analysis.Business.Services;
using AI_CV_Analysis.Data;
using AI_CV_Analysis.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// MSSQL baðlantýsý
builder.Services.AddDbContext<AICVAnalysisDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

// Identity ayarlarý
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AICVAnalysisDbContext>()
    .AddDefaultTokenProviders();



// RoleSeeder servisini ekle
builder.Services.AddScoped<RoleSeeder>();

//
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// RoleSeeder ile rolleri oluþtur
using (var scope = app.Services.CreateScope())
{
    var roleSeeder = scope.ServiceProvider.GetRequiredService<RoleSeeder>();
    await roleSeeder.SeedRolesAsync();
}

// HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization();  // Yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
