﻿using System.Diagnostics.Metrics;
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
string chaine = "server=enzojolys-mysql;port=3306;user=totouser;password=1234;database=toto";


switch (dbDatabase)
{
    case "stub":
        builder.Services.AddSingleton<IDtoManager, Stub>();
        Console.WriteLine($"Erreur {dbDatabase} database-stub ");
        break;
    case "api":
        builder.Services.AddSingleton<IDtoManager, OpenLibClientAPI>();
        Console.WriteLine($"Erreur {dbDatabase} database-api ");
        break;
    case "bdd":
       // builder.Services.AddSingleton<IDtoManager, MyLibraryMgr>();
        builder.Services.AddSingleton<IDtoManager, MyLibraryMgr>( (x) => new MyLibraryMgr(chaine));
        Console.WriteLine($"Erreur {dbDatabase} database-BDD ");
        break;
    default:
        Console.WriteLine($"Erreur {dbDatabase} database ");
        break;
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