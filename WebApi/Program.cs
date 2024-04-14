using Persistence;
using Application;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistence().AddApplication().AddWebApi();

var app = builder.Build();

app.UseWebApi();

app.Run();
