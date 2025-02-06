using FactoryKPIs4.Components;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.DataProtection;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();

builder.Services.AddAntiforgery(options =>
{
    // Suppress the anti-forgery token globally in development for debugging
    options.SuppressXFrameOptionsHeader = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.None; // Disable secure cookie policy for local testing
});

// Persist Data Protection Keys
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\inetpub\wwwroot\FactoryKPIs\Keys"))
    .SetApplicationName("FactoryKPIs");

builder.Services.AddAntiforgery(options => options.SuppressXFrameOptionsHeader = true);

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