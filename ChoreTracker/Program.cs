using ChoreTracker.Models;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data/ChoreTracker.db");

    if (!File.Exists(filePath))
    {
        try
        {
            DataAccess.InitDB();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in creating DB: {ex.Message.ToString()}");
        }

        Console.WriteLine("Database created and configured.");
    }
    else
    {
        Console.WriteLine("Database already configured");
    }
});

app.Run();
