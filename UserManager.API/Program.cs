using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using UserManager.Application.Contract;
using UserManager.Application.Service;
using UserManager.Domain.Ports;
using UserManager.Domain.Services;
using UserManager.Infrastructure.Context;
using UserManager.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .AddJsonFile("appsettings.json", false, true)
    .Build();

/*Creación de validación JWT*/
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionString").Value);
});
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();

var keyBytes=Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;

    // Automatic registration of validators in assembly
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidation();

builder.Services.AddScoped<UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<UserAppService>();
builder.Services.AddTransient<IUserAppService, UserAppService>();

builder.Services.AddScoped<RoleAppService>();
builder.Services.AddTransient<IRoleService, RoleAppService>();

builder.Services.AddScoped<RoleService>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
);
app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();