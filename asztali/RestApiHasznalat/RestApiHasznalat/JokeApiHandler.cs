using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestApiHasznalat
{
    internal class JokeApiHandler
    {
        readonly HttpClient _httpClient;
        public JokeApiHandler(string base_url)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(base_url)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public record JokeResponse(string insult, string created, string createdBy);

        public async Task<JokeResponse?> GetJokeAsync(string path, CancellationToken cancellationToken)
        {
            JokeResponse? response = null;
            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(path, cancellationToken);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string str = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                    response = JsonSerializer.Deserialize<JokeResponse>(str);
                }

            }
            catch { }

            return response;
        }

        //public async Task<JokeResponse> PatchJokeAsync<T>(string path, T data, CancellationToken cancellationToken)
        //{
        //    JokeResponse? response = null;
        //    var dataStr = JsonSerializer.Serialize(data);
        //    HttpResponseMessage responseMessage = await _httpClient.PatchAsync(path, new StringContent(dataStr), cancellationToken);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        string str = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
        //        if (!cancellationToken.IsCancellationRequested)
        //        {
        //            response = JsonSerializer.Deserialize<JokeResponse>(str);
        //        }
        //    }

        //    return response;
        //}
    }
}
