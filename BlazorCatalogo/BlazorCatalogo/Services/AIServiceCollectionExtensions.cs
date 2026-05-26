using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace BlazorCatalogo.Services
{
    public static  class AIServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenAI(this IServiceCollection services,
                                               IConfiguration config)
        {
            var apiKey = config["OpenAI_Key"]
                ?? throw new InvalidOperationException("OpenAI_Key não configurada");

            var client = new OpenAIClient(
                new ApiKeyCredential(apiKey),
                new OpenAIClientOptions
                {
                    Endpoint = new Uri("https://models.inference.ai.azure.com")
                });

            // Chat
            services.AddSingleton<IChatClient>(
                client.GetChatClient("gpt-4o").AsIChatClient()
            );

            // Embeddings
            services.AddSingleton<IEmbeddingGenerator<string, Embedding<float>>>(
                client.GetEmbeddingClient("text-embedding-3-small").AsIEmbeddingGenerator()
            );

            return services;
        }
    }
}