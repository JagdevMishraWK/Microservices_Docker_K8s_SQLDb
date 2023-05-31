using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopping.API.ShoppingContext;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

/* Database Context Dependency Injection */

// This is to read database configuration from appsettings
// var connectionString = builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString");
var connectionString = Environment.GetEnvironmentVariable("DatabaseSettings__ConnectionString");

builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(connectionString));
/* ===================================== */

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI: Antiforgery");
    });
}

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.Use((context, next) =>
{
    var requestPath = context.Request.Path.Value;
    return next(context);
});


app.MapControllers();

app.Run();