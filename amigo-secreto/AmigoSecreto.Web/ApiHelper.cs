using AmigoSecreto.Web.Models;
using Newtonsoft.Json;
using System.Text;

namespace AmigoSecreto.Web
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;
        public ApiHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Configuration.GetApiUrl());
            _httpClient.Timeout = TimeSpan.FromSeconds(40);
        }

        public async Task<string> GetAsync(string uri)
        {
            try
            {
                using (var response = await _httpClient.GetAsync(uri))
                {
                    if (!response.IsSuccessStatusCode)
                        return $"Erro ao realizar chamada na API. StatusCode: {(int)response.StatusCode} {response.Headers}";

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        public async Task<bool> PostAync(string uri, Object obj)
        {
            try
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                    return false;
                else
                    return true; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<List<Amigo>> ObterAmigosAsync(){
           try 
           {
                var result = await GetAsync("/v1/buscar-todos");

                return JsonConvert
                    .DeserializeObject<List<Amigo>>(result)
                    ?.OrderBy(obj => obj.RegistradoEm)
                    .ToList() ?? new List<Amigo>();

            } catch (Exception ex) {
                System.Console.WriteLine(ex.Message);
                return new List<Amigo>();
            }
        }
    }
}