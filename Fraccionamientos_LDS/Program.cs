using Fraccionamientos_LDS.Data;
using Fraccionamientos_LDS.Repositories;
using Fraccionamientos_LDS.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Setting Connection string
string connectionString = builder.Configuration.GetConnectionString("AccaConnection");

builder.Services.AddDbContext<ResidentialContext>(options =>
{
    options.UseSqlServer(connectionString);
});


//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Services
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
