using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using StockVision.Core.Interfaces;
using StockVision.Data.Data;
using StockVision.Service.Interfaces;
using StockVision.Service.Services;
using StockVision.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderBookService, OrderbookService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISectorService, SectorService>();
builder.Services.AddScoped<IStockIndexService, StockIndexService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

var conectionString = builder.Configuration["ConnectionStrings:StockVisionConnectionString"];
builder.Services.AddDbContext<StockVisionContext>(options => options.UseSqlServer(conectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
