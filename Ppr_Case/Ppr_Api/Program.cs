using Ppr_Base;
using Ppr_Bussiness;
using Ppr_Bussiness.Cqrs;
using Ppr_Bussiness.Mapper;
using Ppr_Data.Context;
using Ppr_Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using AutoMapper;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionStringSql = builder.Configuration.GetConnectionString("MsSqlConnection");
builder.Services.AddDbContext<ParaDbContext>(options => options.UseSqlServer(connectionStringSql));

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MapperConfig()); });
builder.Services.AddSingleton(config.CreateMapper());

// Add Authorization, Controllers and MediatR services
builder.Services.AddAuthorization();
builder.Services.AddControllers();
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(CreateAccountCommand).GetTypeInfo().Assembly);

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
