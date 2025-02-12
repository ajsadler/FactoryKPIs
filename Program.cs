using FactoryKPIs.Components;
using FactoryKPIs.Data;
using FactoryKPIs.Services;
using Microsoft.EntityFrameworkCore;

// Creates the Web App builder
var builder = WebApplication.CreateBuilder(args);
// Reads the database connection string in appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container:

// Registers support for Razor components, enabling the app to use both server-side Blazor and interactive components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Registers support for Blazor Bootstrap components, used to create responsive and interactive UI elements
builder.Services.AddBlazorBootstrap();

// Registers the ApplicationDbContext as a service, configures the context to use SQL Server with the connection string that was defined earlier, allowing the Web App to interact with the SQL database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registers scoped services, which means a new instance of each service will be created for each HTTP request
builder.Services.AddScoped<ProductionOrderService>();
builder.Services.AddScoped<NavigationCycleService>();

// Builds the application using the services and configurations defined above
var app = builder.Build();

// Configure the HTTP request pipeline
// If the application is not in development mode, then an exception handler middleware is added to catch exceptions and display an error page
// It also uses HSTS (HTTP Strict Transport Security) for the production environment to enforce secure connections over HTTPS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirect all HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enable serving static files (eg. CSS, JS, images) from the web server
app.UseStaticFiles();

// Adds protection against cross-site request forgery attacks
app.UseAntiforgery();

// Maps the App component to the root URL, and sets the render mode to interactive server-side Blazor. It enables the rendering of Razor components on the server and updates them dynamically on the client
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();