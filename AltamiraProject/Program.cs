using AltamiraProject.Extensions;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using NLog;

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

// Add services to the container.
builder.Services.ConfigureCors();

//Configurar LoggerService
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServices();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.ConfigureValidation();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();
//Configurar RepositoryManager
var app = builder.Build();


//Agregar Exception Handler
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//agregar cors
app.UseCors("CorsPolicy");
//Agregar Authentication
app.UseAuthentication();

app.UseAuthorization();
app.MapControllers();
app.Run();
