using GameChanger.Core;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

var movieApiKey = builder.Configuration["Movies:ServiceApiKey"];


// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddScoped(sp =>
{
    var http = new HttpClient();
    http.BaseAddress = new Uri("https://api.team-manager.gc.com");
    http.DefaultRequestHeaders.Add("gc-token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ijk2MWM1YmM1LWJkM2EtNDg4MS1iMmI0LTgyM2YzOGM0YzBiYyJ9.eyJ0eXBlIjoidXNlciIsImNpZCI6ImFjYWQyNjNmLTNlYzctNGVkZS05MTFmLTIzZjEyODYwZGEwYSIsImVtYWlsIjoia3lsZS5yb2dlcnNAZ21haWwuY29tIiwidXNlcklkIjoiMzZiZTgwYWMtY2UwZC00OTE4LTgzMDYtY2M2MjMzOTZlMmMyIiwicnRrbiI6IjIxNmI3N2NkLWIwODctNDA3YS05ZmRhLWNjZTU1MzNmNGY4YzoxZjdhNmRhYi1kZGVlLTRlZmItYjNkMC1hY2ZlNGQ2MmYyNmYiLCJpYXQiOjE2NTI3MDA0NDIsImV4cCI6MTY1Mjc0MzY0Mn0.Ke9HaMG0cNIifo_ReiKVoWq6uZlhXIEl61c6iLijrmk");
    http.DefaultRequestHeaders.Add("Gc-App-Version", "5.8.1.4");
    http.DefaultRequestHeaders.Add("Gc-App-Name", "iOS");
    http.DefaultRequestHeaders.Add("User-Agent", "odyssey/5.8.1 (com.gc.teammanager; build:4; iOS 15.4.1) Alamofire/5.5.0");
    return http;
});

builder.Services.AddScoped<GameChangerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();
app.UseRouting();

app.MapFallbackToFile("index.html"); ;
app.MapControllers();
app.Run();
