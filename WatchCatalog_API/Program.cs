using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using WatchCatalog_API.Context;
using WatchCatalog_API.Filters;
using WatchCatalog_API.Interfaces;
using WatchCatalog_API.Repository;
using WatchCatalog_API.Services;

var builder = WebApplication.CreateBuilder(args);
var storageConnection = builder.Configuration.GetValue<string>("Connection:Azure:Blob");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContextPool<WatchContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IWatchRepository, WatchRepository>();
builder.Services.AddScoped<IWatchService, WatchService>();
builder.Services.AddScoped<IAzureStorageService, AzureStorageService>();
builder.Services.AddMvc(builder => builder.Filters.Add(new GlobalExceptionFilter()));
builder.Services.AddAzureClients(azureBuilder => azureBuilder.AddBlobServiceClient(storageConnection));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
