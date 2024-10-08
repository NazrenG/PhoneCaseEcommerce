using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.Business.Concretes;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.DataAccess.Concretes;
using PhoneCaseEcommerce.Entities.Models;
using PhoneCaseEcommerce.WebUI.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<PhoneCaseEcommerceDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});

builder.Services.AddDbContext<CustomIdentiyDbContext>(opt =>opt.UseSqlServer(conn));
builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentiyDbContext>()
    .AddDefaultTokenProviders();

 

builder.Services.AddScoped<IPhoneCasesDal, PhoneCaseDal>();
builder.Services.AddScoped<IPhoneCaseService, PhoneCaseService>();
builder.Services.AddScoped<IModelDal, ModelDal>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IColorDal, ColorDal>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IFavDal, FavDal>();
builder.Services.AddScoped<IFavService, FavService>();




builder.Services.AddScoped<IAuthDal, AuthDal>();


var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(key),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = false,

                   };
               });
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
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
