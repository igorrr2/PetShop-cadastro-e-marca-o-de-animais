using ApiPetShopLibrary.Animal;
using ApiPetShopLibrary.BanhoTosa;
using ApiPetShopLibrary.Login;
using System.Net.Http;
using System.Net.Http.Json;
using Util.MensagemRetorno;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetShopClient
{
    public class Client
    {
        private readonly HttpClient _httpClient;

        public Client()
        {
            _httpClient = new HttpClient
            {
                //BaseAddress = new Uri("https://restpetshop.onrender.com/"),
                BaseAddress = new Uri("http://localhost:5036/"),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<(Mensagem mensagem, LoginResposta loginResposta)> LogarAsync(string login, string senha)
        {
            var solicitacao = new LoginSolicitacao
            {
                Login = login,
                Senha = senha
            };

            try
            {
                // Envia POST para /Login/Logar com body JSON
                var response = await _httpClient.PostAsJsonAsync("Login/Logar", solicitacao);

                // Lança exceção se não for 2xx
                response.EnsureSuccessStatusCode();

                // Desserializa JSON de volta para LoginResposta
                var loginResposta = await response.Content.ReadFromJsonAsync<LoginResposta>();

                return (new Mensagem(), loginResposta);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem(string.Format("Erro ao acessar a API: {0}" + ex.Message)), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem(string.Format("Erro inesperado: {0}", ex.Message)), null);
            }
        }

        public async Task<DeslogarResposta> DeslogarAsync(string token)
        {
            var solicitacao = new DeslogarSolicitacao
            {
                Token = token
            };

            try
            {
                // Envia POST para /Login/Logar com body JSON
                var response = await _httpClient.PostAsJsonAsync("Login/Deslogar", solicitacao);

                // Lança exceção se não for 2xx
                response.EnsureSuccessStatusCode();

                // Desserializa JSON de volta para LoginResposta
                var loginResposta = await response.Content.ReadFromJsonAsync<DeslogarResposta>();

                return loginResposta;
            }
            catch (HttpRequestException ex)
            {
                return new DeslogarResposta
                {
                    statusCode = 500,
                    MensagemRetorno = "Erro ao acessar a API: " + ex.Message
                };
            }
            catch (Exception ex)
            {
                return new DeslogarResposta
                {
                    statusCode = 500,
                    MensagemRetorno = "Erro inesperado: " + ex.Message
                };
            }
        }

        public async Task<(Mensagem mensagem, AnimalResposta resposta)> ListarAnimaisAsync(AnimalListarSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<AnimalResposta>($"api/Animal/ListarAnimais?Token={solicitacao.Token}");
                return (new Mensagem(), response);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AnimalResposta resposta)> CadastrarAnimalAsync(AnimalSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Animal/CadastrarAnimal", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AnimalResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AnimalResposta resposta)> AtualizarAnimalAsync(AnimalSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Animal/AtualizarAnimal", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AnimalResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AnimalResposta resposta)> ApagarAnimalAsync(AnimalApagarSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Animal/ApagarAnimal", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AnimalResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AgendamentoBanhoTosaResposta resposta)> ListarAgendamentosAsync(AgendamentoBanhoTosaListarSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/BanhoTosa/ListarAgendamentosBanhoTosa?Token={solicitacao.Token}");
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AgendamentoBanhoTosaResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AgendamentoBanhoTosaResposta resposta)> CadastrarAgendamentoAsync(AgendamentoBanhoTosaSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/BanhoTosa/CadastrarAgendamentoBanhoTosa", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AgendamentoBanhoTosaResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AgendamentoBanhoTosaResposta resposta)> AtualizarAgendamentoAsync(AgendamentoBanhoTosaSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/BanhoTosa/AtualizarAgendamentoBanhoTosa", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AgendamentoBanhoTosaResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AgendamentoBanhoTosaResposta resposta)> ApagarAgendamentoAsync(AgendamentoBanhoTosaApagarSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/BanhoTosa/ApagarAgendamentoBanhoTosa", solicitacao);
                response.EnsureSuccessStatusCode();
                var resultado = await response.Content.ReadFromJsonAsync<AgendamentoBanhoTosaResposta>();
                return (new Mensagem(), resultado);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }
        }

        public async Task<(Mensagem mensagem, AlterarSenhaResposta resposta)> AlterarSenhaAsync(AlterarSenhaSolicitacao solicitacao)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Login/AlterarSenha", solicitacao);

                response.EnsureSuccessStatusCode();

                var alterarSenhaResposta = await response.Content.ReadFromJsonAsync<AlterarSenhaResposta>();

                return (new Mensagem(), alterarSenhaResposta);
            }
            catch (HttpRequestException ex)
            {
                return (new Mensagem($"Erro ao acessar a API: {ex.Message}"), null);
            }
            catch (Exception ex)
            {
                return (new Mensagem($"Erro inesperado: {ex.Message}"), null);
            }

        }
    }
}