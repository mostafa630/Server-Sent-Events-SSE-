using System.Text.Json;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()  // allow all origins
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


// simulate notifications data source
var notificatons = new[]
{
    new { Type = "info", Message = "Server started successfully." },
    new { Type = "user", Message = "New user joined: Sasa" },
    new { Type = "chat", Message = "New message: 'Hello everyone!'" },
    new { Type = "system", Message = "Backup completed." }
};


app.MapGet("/events", async context =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    context.Response.Headers.Add("Cache-Control", "no-cache");
    context.Response.Headers.Add("Content-Type", "text/event-stream");
    context.Response.Headers.Add("Connection", "keep-alive");


    var random = new Random();

    while (true)
    {
        var notify = notificatons[random.Next(notificatons.Length)];
        var json = JsonSerializer.Serialize(notify);

        // SSE format: each message starts with "data: " and ends with double newline
        await context.Response.WriteAsync($"data: {json}\n\n");
        await context.Response.Body.FlushAsync();

        await Task.Delay(3000);
    }

});

app.Run();
