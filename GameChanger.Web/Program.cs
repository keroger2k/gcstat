using GameChanger.Core;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(sp =>
{
    var http = new HttpClient();
    http.BaseAddress = new Uri("https://api.team-manager.gc.com");
    http.DefaultRequestHeaders.Add("gc-token", builder.Configuration.GetValue<string>("GC-TOKEN"));
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
