using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using Microsoft.OpenApi.Models;
using OnlineShop.Services.User;
using OnlineShop.Repository.User;
using Microsoft.AspNetCore.Hosting;
using OnlineShop.Services;
using AutoMapper;
using OnlineShop.Repository.ProductCategory;
using OnlineShop.Services.ProductCategory;


var builder = WebApplication.CreateBuilder(args);


#region Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();


#endregion

#region Repository

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddSwaggerGen();
//JSON serializer to ignore or preserve reference loops
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
