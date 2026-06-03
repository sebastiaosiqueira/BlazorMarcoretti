
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace BlazorMangas.Service.Autentica
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Seu código original que busca os dados do LocalStorage
                var savedToken = await _localStorage.GetItemAsync<string>("authToken");
                var expirationToken = await _localStorage.GetItemAsync<string>("tokenExperiration");

                if (string.IsNullOrWhiteSpace(savedToken) || TokenExpirou(expirationToken))
                {
                    // Executa o logout se o token não existir ou estiver expirado
                    MarkUserAsLoggedOut();
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // Retorna o usuário autenticado caso o token seja válido
                return new AuthenticationState(new ClaimsPrincipal(
                    new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
            }
            catch (InvalidOperationException)
            {
                // Captura a falha de Prerender no servidor (quando o JS ainda não está disponível)
                // Retornamos um usuário vazio temporário. Quando o app carregar no browser,
                // o Blazor chamará este método de novo e o código do 'try' vai rodar com sucesso.
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public void MarkUserAsLoggedOut()
        {
           var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);    
        }

        public void MarakUserAsAuthenticated(string email)
        {
            var authenticateUser = new ClaimsPrincipal(new ClaimsIdentity(
                new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }, "apiauth"));

            var authState = Task.FromResult(new AuthenticationState(authenticateUser));
            NotifyAuthenticationStateChanged(authState);
        }

        private IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());
                    foreach (var parsedRole in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }
                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private bool TokenExpirou(string dataToken)
        {
           DateTime dataAtualUtc = DateTime.UtcNow;
            DateTime dataExpiracao=  DateTime.ParseExact(dataToken, "yyyy-MM-dd´T'HH:mm:ss.ffffff'z'", null, System.Globalization.DateTimeStyles.RoundtripKind);
            if(dataExpiracao < dataAtualUtc)
            {
                return true;
            }
            return false;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }
}
