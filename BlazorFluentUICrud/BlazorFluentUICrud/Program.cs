using BlazorFluentUICrud.Components;
using BlazorFluentUICrud.Context;
using BlazorFluentUICrud.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.FluentUI.AspNetCore.Components;
using SQLitePCL;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();


var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContextFactory<AppDbContext>(
    opt => opt.UseSqlite(connectionString));

builder.Services.AddScoped<IAlunoService, AlunoService>();

Batteries.Init();
var app = builder.Build();
CreateDatabase(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
    using var scope = app.Services.CreateScope();
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var context = factory.CreateDbContext();

    // Força a criação do arquivo e das tabelas
    // Se o arquivo não existir, o EF Core vai criar agora
    context.Database.EnsureDeleted(); // CUIDADO: Isso apaga o banco atual se existir (bom para limpar erros)
    context.Database.EnsureCreated();
}
