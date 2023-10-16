using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prova.B3.Api;
using Prova.B3.Domain.Model;
using Prova.B3.Domain.Validator;
using Prova.B3.Repository;
using Prova.B3.Repository.Context;
using Prova.B3.Repository.Interfaces;
using Prova.B3.Services;
using Prova.B3.Services.Interfaces;


var AllowAll = "AllowAll";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<B3Context>(opt => opt.UseInMemoryDatabase("InMemory"));
builder.Services.TryAddScoped<ICdbService, CdbService>();
builder.Services.TryAddScoped<ICdbRepository, CdbRepository>();
builder.Services.TryAddScoped<ITaxasRepository, TaxaRepository>();
builder.Services.AddHostedService<DataBaseStart>();
builder.Services.AddScoped<IValidator<Cdb>, CdbValidator>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAll,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(AllowAll);
app.UseAuthorization();

app.MapControllers();

app.Run();

