using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyceliumServer.Data;
using MyceliumServer.GameStuff;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<Player>();
//builder.Services.AddSingleton<TwitchService>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

string getConfig(string configReference, WebApplicationBuilder builder) {
    if (builder == null) {
        throw new ArgumentNullException("Builder cannot be null", nameof(builder));
    }
    var configResult = builder.Configuration[configReference];

    if (configResult == null) {
        throw new NullReferenceException("Configuration Reference returned Null");
    }
    return configResult;
}