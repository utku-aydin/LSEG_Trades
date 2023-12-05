using LSEG_Trades.Api.Controllers.HttpDataClient;
using LSEG_Trades.Api.Controllers.HttpDataClient.Interfaces;
using LSEG_Trades.Api.Data.ObjectRelationalMapping;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories;
using LSEG_Trades.Api.Data.ObjectRelationalMapping.Repositories.Interfaces;
using LSEG_Trades.Api.Service.Payment;
using LSEG_Trades.Api.Service.Payment.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TradeDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<ITradeService, TradeService>();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IExternalServiceClient, HttpExternalServiceClient>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

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
