using LabaWork.Models;
using LabaWork.Models.ModelAndErrors;
using LabaWork.Services;
using LabaWork.Services.Abstract;
using LabaWork.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProductContext>(option => option.UseNpgsql(connection));
builder.Services.AddScoped<IProductService, ProductService>();    
builder.Services.AddScoped<ICategoryService, CategoryService>();    
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ProductValidator>();
builder.Services.AddScoped<CreateProduct>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderValidator>();
builder.Services.AddScoped<OrderAndErrors>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=AllProducts}/{id?}");

app.Run();