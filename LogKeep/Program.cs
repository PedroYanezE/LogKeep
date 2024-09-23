using LogKeep.Models;
using LogKeep.Services;
using LogKeep.Services.AuditLogs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var mongoDbSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddDbContext<LogKeepDbContext>(options =>
    options.UseMongoDB(mongoDbSettings.AtlasURI ?? "", mongoDbSettings.DatabaseName ?? "")
);

builder.Services.AddScoped<IStructureService, StructureService>();

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

app.UseHttpsRedirection();

app.UseCors("AllowAngularOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
