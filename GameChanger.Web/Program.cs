using GameChanger.Core;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();


builder.Services.AddScoped(sp =>
{
    var http = new HttpClient();
    http.BaseAddress = new Uri("https://api.team-manager.gc.com");
    http.DefaultRequestHeaders.Add("gc-token", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6Ijk2MWM1YmM1LWJkM2EtNDg4MS1iMmI0LTgyM2YzOGM0YzBiYyJ9.eyJ0eXBlIjoidXNlciIsImNpZCI6IjExNTQyMzJiLTQ3NWUtNDA3Ny04ZWJiLTAyMmE2ZjUxN2QxNSIsImVtYWlsIjoia3lsZS5yb2dlcnNAZ21haWwuY29tIiwidXNlcklkIjoiMzZiZTgwYWMtY2UwZC00OTE4LTgzMDYtY2M2MjMzOTZlMmMyIiwicnRrbiI6Ijk0YjNkYjczLThmYjYtNDAwNS1iYjc4LTZiYWI0MDE3N2Q1MzowYjhlOGY5ZS04MDRiLTQ1NWItYjY3NC1hM2Y5ZWQ2NGY1OGMiLCJpYXQiOjE2NTE3OTU5ODAsImV4cCI6MTY1MTgzOTE4MH0.Ychx5vvyWp7sTK44FS4Y2vs73aFUe5rvKRXgMdaoPQg");
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
