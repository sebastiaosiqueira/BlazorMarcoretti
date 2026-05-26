using BlazorCatalogo.Components;
using BlazorCatalogo.Data;
using BlazorCatalogo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddOpenAI(builder.Configuration);


builder.Services.AddSingleton<ProdutoRepository>();
builder.Services.AddSingleton<VetorStore>();
builder.Services.AddSingleton<EmbeddingService>();
builder.Services.AddSingleton<ProdutoRAGService>();
builder.Services.AddSingleton<IndexadorProdutos>();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var indexador = scope.ServiceProvider.GetRequiredService<IndexadorProdutos>();
    var repo = scope.ServiceProvider.GetRequiredService<ProdutoRepository>();
    var embedding = scope.ServiceProvider.GetRequiredService<EmbeddingService>();
    var store = scope.ServiceProvider.GetRequiredService<VetorStore>();
    await indexador.Indexar(repo, embedding, store);
}
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
