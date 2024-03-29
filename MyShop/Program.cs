using Contracts.RepositoryContract;
using Entities;
using Entities.DTO.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService;
using MyShop.Services.BuyerService.Contracts;

using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<RepositoryContext>(options
    =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString("localhost"));
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"));
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IBuyerServiceManager, BuyerServiceManager>();
builder.Services.AddScoped<IAdminServiceManager, AdminServiceManager>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
options.AddPolicy("CorsPolicy", builder =>
builder.AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins(
    "https://localhost:5001",
        "https://localhost:5000",
        "https://localhost:44398",
        "https://localhost:44398"
        , "https://localhost:44352")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    {
        Description = "Enter like this: Bearer mkdfmlkmdflmdklfmdklfmkdfmdfdf",
        Name = "Authorization",
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    });
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        { new OpenApiSecurityScheme()
        {
            Reference = new OpenApiReference()
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme,
            },
        },
      Array.Empty<string>()
        }
    });
}
);


//JWT
IConfiguration appsettings = builder.Configuration.GetSection("Appsettings");
builder.Services.Configure<AppSettings>(appsettings);
AppSettings settings = appsettings.Get<AppSettings>();
var secretkey = System.Text.Encoding.UTF8.GetBytes(settings.SecretKey);

builder.Services.AddAuthentication(
    x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(secretkey),
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuer = false,
        };
    }


    // x.RequireHttpsMetadata = true  request https dan yuboroilsagina qabul qiladi
    );
//**********************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();
