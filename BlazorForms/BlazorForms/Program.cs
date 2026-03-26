using BlazorForms.Components;
using BlazorForms.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SQLitePCL;

var builder = WebApplication.CreateBuilder(args);
Batteries.Init();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");

builder.Services.AddDbContextFactory<AppDbContext>(
    opt=> opt.UseSqlite(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

CreateDatabase(app);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static void CreateDatabase(WebApplication app)
{
    using var serviceScope = app.Services.CreateScope();
    // Buscamos o Factory aqui:
    var factory = serviceScope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();

    // Criamos um contexto temporário apenas para garantir que o banco existe
    using var dataContext = factory.CreateDbContext();
    dataContext.Database.EnsureCreated();
}