using CurrenciesProject.Business.Services;
using CurrenciesProject.Core;
using CurrenciesProject.Business.Jobs;
using CurrenciesProject.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddDbContext<MasterContext>(
    options => options.UseNpgsql(Environment.GetEnvironmentVariable("PostgreUri")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleWare>();
app.MapControllers();
//job trigger tetikleniyor
GetCurrencyScheduler getCurrency = new GetCurrencyScheduler();
getCurrency.TriggerCurrency();
app.Run();
