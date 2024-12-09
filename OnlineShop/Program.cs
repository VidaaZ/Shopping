using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Services.User;
using OnlineShop.Repository.User;
using OnlineShop.Repository.ProductCategory;
using OnlineShop.Services.ProductCategory;
using OnlineShop.Services.Product;
using OnlineShop.Repository.Product;
using AutoMapper;
using OnlineShop.Mappings;
using OnlineShop.Services.SignUp_UserInformation;
using OnlineShop.Repository.UserInformation_SignUp;
using OnlineShop.Repository.SignUp_UserInformation;

var builder = WebApplication.CreateBuilder(args);

// Register AutoMapper manually
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProductMappingProfile());
    mc.AddProfile(new SignUpMappingProfile());
});
IMapper mapper = mappingConfig.CreateMapper();

#region Services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
        policy.WithOrigins("http://localhost:3000") // React app's URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISignUpService, SignUpService>();

builder.Services.AddSingleton(mapper);
#endregion

#region Repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<ISignUpRepository, SignUpRepository>();
#endregion

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSwaggerGen();

// JSON serializer to handle reference loops
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable Swagger for API documentation
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

// Enable CORS
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
