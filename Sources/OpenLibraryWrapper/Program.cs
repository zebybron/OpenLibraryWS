﻿using System.Reflection;
using DtoAbstractLayer;
using LibraryDTO;
using Microsoft.OpenApi.Models;
using MyLibraryDB;
using MyLibraryManager;
using OpenLibraryClient;
using StubbedDTO;

var builder = WebApplication.CreateBuilder(args);

var dbDatabase = Environment.GetEnvironmentVariable("DB_DATABASE");

/*
if ( dbDatabase == "stub")
{
    builder.Services.AddSingleton<IDtoManager, Stub>();
}
if (dbDatabase == "api")
{

    builder.Services.AddSingleton<IDtoManager, OpenLibClientAPI>();
    //builder.Services.AddSingleton<IDtoManager, Stub>();
}
else
{
    //builder.Services.AddSingleton<IDtoManager, MyLibraryMgr>();
}*/
builder.Services.AddSingleton<IDtoManager, OpenLibClientAPI>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();