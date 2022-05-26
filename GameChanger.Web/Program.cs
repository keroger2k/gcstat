using GameChanger.Core;
using GameChanger.Web.Authorization;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(sp =>
{
    var http = new HttpClient();
    var token = AuthorizationHelper.GetAuthorizationToken(builder.Configuration.GetValue<string>("GC-USERNAME"), builder.Configuration.GetValue<string>("GC-PASSWORD"));
    http.BaseAddress = new Uri("https://api.team-manager.gc.com");
    http.DefaultRequestHeaders.Add("gc-token", token);
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
