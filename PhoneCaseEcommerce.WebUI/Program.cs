using Microsoft.EntityFrameworkCore;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.Business.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.DataAccess.Concretes;
using PhoneCaseEcommerce.Entities.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PhoneCaseEcommerceDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddScoped<IPhoneCasesDal,PhoneCaseDal>();
builder.Services.AddScoped<IPhoneCaseService,PhoneCaseService>();


builder.Services.AddScoped<IVendorDal, VendorDal>();
builder.Services.AddScoped<IVendorService, VendorService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
