using ArticlesPlataform.Components;
using MudBlazor.Services;
using ArticlesPlataform.Services;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure |DataDirectory| para AttachDbFilename
var dataDir = Path.Combine(builder.Environment.ContentRootPath, "Data");
if (!Directory.Exists(dataDir))
{
    Directory.CreateDirectory(dataDir);
}
AppContext.SetData("DataDirectory", dataDir);

// Garantir que o banco de dados LocalDB exista e esteja attached
try
{
    var masterConnStr = "Server=(localdb)\\\\mssqllocaldb;Integrated Security=True;";
    var dbName = "MeuProjetoArtigos";
    var dbFile = Path.Combine(dataDir, dbName + ".mdf");

    using (var masterConn = new SqlConnection(masterConnStr))
    {
        masterConn.Open();
        using (var cmd = masterConn.CreateCommand())
        {
            // Escapa aspas simples no caminho do arquivo para evitar erros de SQL
            string escapedDbFile = dbFile.Replace("'", "''");

            // Removido o ')' extra e corrigido o fechamento da string
            cmd.CommandText = $@"
            IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{dbName}') 
            BEGIN 
                CREATE DATABASE [{dbName}] ON (NAME = N'{dbName}', FILENAME = '{escapedDbFile}') 
            END";

            cmd.ExecuteNonQuery();
        }
    }
}
catch
{
    // Não falhar na inicialização do app por problemas de criação do DB local.
    // Em produção, registre o erro adequadamente.
}

// Add MudBlazor services
builder.Services.AddMudServices();

// Theme service for runtime theme switching
builder.Services.AddSingleton<IThemeService, ThemeService>();           

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
