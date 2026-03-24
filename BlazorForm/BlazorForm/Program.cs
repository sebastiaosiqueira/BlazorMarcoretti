using BlazorForm.Components;
using BlazorForm.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Serviços padrão do Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Configuração do SQLite com FACTORY (Obrigatório para Blazor)
var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContextFactory<AppDbContext>(
    opt => opt.UseSqlite(connectionString));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// 3. Chamada da criação do banco (Ajustada para a Factory)
CreateDatabase(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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

// 4. Método CreateDatabase Corrigido
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