using Hangfire;
using Hangfire.API.Model;
using Hangfire.API.Repositories;
using Hangfire.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionStrings:SqlServer"];

builder.Services.AddSingleton<IUserRepository, UserRepository>();

//Database
builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(connectionString));

//HangFire
builder.Services.AddHangfire(config => config
    .UseSqlServerStorage(connectionString));

builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//HangFire
app.UseHangfireDashboard();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
