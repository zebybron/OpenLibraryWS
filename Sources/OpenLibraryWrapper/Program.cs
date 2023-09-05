using System.Reflection;
using DtoAbstractLayer;
using LibraryDTO;
using Microsoft.OpenApi.Models;
using OpenLibraryClient;
using StubbedDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IDtoManager,OpenLibClientAPI>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

