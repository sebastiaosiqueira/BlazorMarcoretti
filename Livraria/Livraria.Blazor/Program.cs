using Livraria.Blazor.Components;
using Livraria.CrossCutting.DependenciesApp;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
//criacao do banco de dados;
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
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    using var context = factory.CreateDbContext();

    // Força a criação do arquivo e das tabelas
    // Se o arquivo não existir, o EF Core vai criar agora
    context.Database.EnsureDeleted(); // CUIDADO: Isso apaga o banco atual se existir (bom para limpar erros)
    context.Database.EnsureCreated();
}
