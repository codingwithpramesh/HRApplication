using HRApplication.Data;
using HRApplication.Data.Repository;
using HRApplication.Data.Services;
using HRApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Identity

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

    options.SignIn.RequireConfirmedEmail = true;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(20);
    options.Lockout.MaxFailedAccessAttempts = 3;
});


builder.Services.AddSession();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromMinutes(5);
});


builder.Services.ConfigureApplicationCookie(op =>
{
    // op.LoginPath = "Account/Login";
});

//Scoped
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddScoped<IEmployeeRegister, EmployeeRegisterService>();
builder.Services.AddScoped<IHRServices, HRServices>();
builder.Services.AddScoped<ILeaveServices, LeaveServices>();
builder.Services.AddScoped<IEmployeeAttendenceService, EmployeeAttendenceService>();
builder.Services.AddScoped<IcheckInOutServices, CheckInOutServices>();
builder.Services.Configure<SmtpConfigModel>(builder.Configuration.GetSection("SMTPConfig"));
//builder.Services.Configure<SMTPConfig>(builder.Configuration.GetSection("SMTPConfig"));



builder.Services.AddHttpContextAccessor();


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

app.UseSession();


/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "HR",
      pattern: "HR/{controller=EmployeeAttendence}/{action=Index}/{id?}"
    );
});*/

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//      name: "Employees",
//      pattern: "Employees/{controller=Home}/{action=Index}/{id?}"
//    );
//});

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "HR",
      pattern: "HR/{controller=EmployeeAttendence}/{action=Index}/{id?}"
    );
});*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
