using InsuranceManagementAPI.Data;
using InsuranceManagementAPI.Data.Repository;
using InsuranceManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Database Services
builder.Services.AddDbContext<PolicyDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PolicyAPIConnectionString")));

// Configure Autor Mapper
builder.Services.AddAutoMapper(typeof(Program));

// Configure App Services
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBankRepository, BankRepository>();


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
