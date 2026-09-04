using Microsoft.EntityFrameworkCore;
using TaskManagementFa.Data;
using TaskManagementFa.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Configuration
//       .GetSection("DatabaseSettings")["DefaultConnection"];
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
