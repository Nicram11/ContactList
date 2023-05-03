using ContactList.Data;
using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ContactsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IPasswordHasher<Contact>,PasswordHasher<Contact>>();
builder.Services.AddIdentity<Contact, IdentityRole>()
   .AddEntityFrameworkStores<ContactsDbContext>()
   .AddUserManager<ContactService>()
   .AddUserValidator<UserValidator<Contact>>()
   .AddPasswordValidator<PasswordValidator<Contact>>()
   .AddDefaultTokenProviders();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

DataSeeder.Seed(app.Services);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
