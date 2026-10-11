using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManagementFa.Data;
using TaskManagementFa.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtkey = builder.Configuration["Jwt:Key"];
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtkey!))
        };
    });
//builder.Configuration
//       .GetSection("DatabaseSettings")["DefaultConnection"];
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }