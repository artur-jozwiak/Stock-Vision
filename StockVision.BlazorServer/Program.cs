using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using StockVision.BlazorServer.Data;
using StockVision.Core.Interfaces;
using StockVision.Data.Data;
using StockVision.Service;
using StockVision.Service.Interfaces;
using StockVision.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IOrderBookService, OrderbookService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var conectionString = builder.Configuration["ConnectionStrings:StockVisionConnectionString"];
builder.Services.AddDbContext<StockVisionContext>(options => options
    //.UseLazyLoadingProxies()
    .UseSqlServer(conectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
