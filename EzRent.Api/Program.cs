using System;
using System.Reflection;
using EzRent.Domain.Entities;
using EzRent.Infrastructure.Context;
using EzRent.Infrastructure.Repository.Properties;
using EzRent.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
//Entity Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnectionMySql"),serverVersion));

//Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:44339")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

//Swagger
builder.Services.AddSwaggerGen();

//Mvc
builder.Services.AddMvc();

//Identity
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Mediator
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(MediatorHandler))
                                                                 ?? throw new ArgumentNullException(nameof(MediatorHandler))));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Generics Repository
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EzRent.Api v1");
    c.DefaultModelsExpandDepth(-1);
});

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
