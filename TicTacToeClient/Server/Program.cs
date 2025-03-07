using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToeClient.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Dodaj SignalR
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapHub<GameHub>("/gameHub"); // Ruta za SignalR Hub
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
