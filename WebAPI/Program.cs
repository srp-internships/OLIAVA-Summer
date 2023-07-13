global using WebAPI.Models;
global using WebAPI.DTOs.Character;
global using WebAPI.Services.CharacterService;
global using Microsoft.EntityFrameworkCore;
global using WebAPI.Data;
global using System.Security.Cryptography;
global using Microsoft.AspNetCore.Mvc;
global using System.Text;
global using System.Security.Claims;
global using System.IdentityModel.Tokens.Jwt;
global using Microsoft.IdentityModel.Tokens;
global using WebAPI.DTOs.User;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var constr=builder.Configuration.GetConnectionString("DefaultConnetion");
constr = "Server=.\\SQLExpress;Database=dotnet-rpg;Trusted_Connection=true;TrustServerCertificate=true;";
builder.Services.AddDbContext<DataContext>( options => options.UseSqlServer(constr));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
        Description = """Standart Authorization header using the BEarer scheme. Example: "bearer{token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
