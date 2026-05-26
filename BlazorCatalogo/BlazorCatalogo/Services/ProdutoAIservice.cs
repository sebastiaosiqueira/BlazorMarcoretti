using BlazorCatalogo.Data;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace BlazorCatalogo.Services;

public class ProdutoAIService
{
    private readonly IConfiguration _config;

    public ProdutoAIService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> PerguntarSobreProduto(Produto produto, string pergunta)
    {
        var apiKey = _config["OpenAI_Key"]
           ?? throw new InvalidOperationException("OpenAI_Key não configurada");

        if (string.IsNullOrEmpty(apiKey))
            Console.WriteLine("DEBUG: A CHAVE NÃO FOI ENCONTRADA!");
        else
            Console.WriteLine($"DEBUG: Chave carregada. Começa com: {apiKey.Substring(0, 4)}");

        var openAIClient = new OpenAIClient(
               new ApiKeyCredential(apiKey),
               new OpenAIClientOptions
               {
                   Endpoint = new Uri("https://models.inference.ai.azure.com")
               });

        IChatClient client = openAIClient
            .GetChatClient("gpt-4o")
            .AsIChatClient();

        var prompt = $"""
        Você é um assistente especializado em responder dúvidas sobre produtos.

        Use EXCLUSIVAMENTE as informações abaixo:

        {produto.DocumentoInformacoes}

        Pergunta do cliente:
        {pergunta}

        Se a resposta não estiver no documento, diga:
        "Não tenho essa informação disponível."
        """;
        try
        {
            var response = await client.GetResponseAsync(prompt);
            return response.Messages.FirstOrDefault()?.Text ??
                "Não tenho essa informação disponível";
        }catch (System.ClientModel.ClientResultException ex)
        {
            // Logar o erro, se necessário
            return "Erro: Token do GitHub inválido ou expirado. Gere um novo PAT.";
        }
        catch(Exception ex)
        {
            // Logar o erro, se necessário
            return $"Erro na IA: {ex.Message}";
        }

    }

}
