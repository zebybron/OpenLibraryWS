using System.Reflection;
using DtoAbstractLayer;
using LibraryDTO;
using Microsoft.OpenApi.Models;
using MyLibraryDB;
using MyLibraryManager;
using OpenLibraryClient;
using StubbedDTO;

var builder = WebApplication.CreateBuilder(args);

var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");
if ( dbDatabase.Equals("stub"))
{
    builder.Services.AddSingleton<IDtoManager, Stub>();
}
 else
{
    builder.Services.AddSingleton<IDtoManager, MyLibraryMgr>();
}



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();