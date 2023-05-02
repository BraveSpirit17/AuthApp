using System.Text;
using AuthApp.Application.Interfaces;
using AuthApp.Application.Options;
using AuthApp.Application.Services;
using AuthApp.Core.Repositories;
using AuthApp.Core.Repositories.Base;
using AuthApp.Infrastructure.Data;
using AuthApp.Infrastructure.Repositories;
using AuthApp.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<AuthAppContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddTransient<IUserRepository, UserRepository>();
services.AddTransient<ITokenService, TokenService>();
services.AddTransient<IPasswordHashingService, PasswordHashingService>();

services.AddControllers();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtOptions:Audience"],
        ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();