using Microsoft.EntityFrameworkCore;
using StockVision.Core.Interfaces;
using StockVision.Core.Services;
using StockVision.Data.Data;
using StockVison.Scraper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISheetScrapper, SheetScraper>();
builder.Services.AddScoped<IPriceScrapper, PriceScrapper>();
builder.Services.AddScoped<IGPWCompositionReader, GPWCompositionReader>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var conectionString = builder.Configuration["ConnectionStrings:StockVisionConnectionString"];
builder.Services.AddDbContext<StockVisionContext>(options => options
    //.UseLazyLoadingProxies()
    .UseSqlServer(conectionString));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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
