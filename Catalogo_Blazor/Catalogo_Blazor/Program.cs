
using Catalogo_Blazor.Server.Components;
using Catalogo_Blazor.Server.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient
{
    // Como é HTTP puro, não precisamos de handlers de certificado
    BaseAddress = new Uri("http://localhost:5217/")
});
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options=> 
options.UseSqlServer(connection));
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
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    // Use o nome de uma classe que você sabe que existe no projeto Client
    // Se o seu projeto Client se chama Catalogo_Blazor.Client:
    .AddAdditionalAssemblies(typeof(Catalogo_Blazor.Components._Imports).Assembly);

app.Run();
