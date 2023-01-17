
using SummerProgramDemo.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SummerProgramDemo.Areas.Identity.Data;
using SummerProgramDemo.Services;
using SummerProgramDemo.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddSqlServer<UserProfileDbContext>(
    builder.Configuration.GetConnectionString("defaultConnectionString"));

builder.Services.AddDbContext<UserProfileDbContext>(options =>
    options.UseSqlServer("defaultConnectionString"));

builder.Services.AddScoped<IRegister, Register>();
builder.Services.AddScoped<ILogIn, Login>();
builder.Services.AddScoped<IRole, Role>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddDefaultIdentity<SummerProgramDemoUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<UserProfileDbContext>();


//builder.Services.AddDefaultIdentity<SummerProgramDemoUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<UserProfileDbContext>();
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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
