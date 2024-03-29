using WebBlazor.Components;
using LibraryShared.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<Cliente>();
builder.Services.AddScoped<Produto>();
builder.Services.AddScoped<Pedido>();
builder.Services.AddScoped<ItPedido>();
builder.Services.AddScoped<Usuario>();
builder.Services.AddScoped<VariaveisGlobais>();


builder.Services.AddScoped<HttpClient>(x =>
   {
       return new HttpClient
       { BaseAddress = new Uri(@"https://localhost:7198") };
   });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
