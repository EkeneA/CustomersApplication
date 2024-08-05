using CustomersApplication.Core.WebApi.Interfaces;
using System.Net.Http.Json;

namespace CustomersApplication.Buisness.WebApi
{
    public sealed class WebApiService : IWebApiService
    {
        private static HttpClient _sharedClient = new();
        public WebApiService()
        {
            _sharedClient = new()
            {
                BaseAddress = new Uri("https://localhost:7284/api/"),
            };
        }

        public async Task<TResponse> DeleteAsync<TResponse>(string requestURL)
        {
            var response = await _sharedClient.DeleteFromJsonAsync<TResponse>(requestURL);

            return response;
        }

        public async Task<TResponse> GetAsync<TResponse>(string requestURL)
        {
            // GetFromJsonAsync extension calls response.EnsureSuccessStatusCode() to ensure API validation
            var response = await _sharedClient.GetFromJsonAsync<TResponse>(requestURL);

            return response;
        }

        public async Task<TResponse> PatchAsync<TRequest, TResponse>(string requestURL, TRequest content)
        {
            using HttpResponseMessage response = await _sharedClient.PatchAsJsonAsync(requestURL, content);

            // API validation
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TResponse>();
            return result;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestURL, TRequest content)
        {
            using HttpResponseMessage response = await _sharedClient.PostAsJsonAsync(requestURL, content);

            // API validation
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TResponse>();
            return result;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string requestURL, TRequest content)
        {
            using HttpResponseMessage response = await _sharedClient.PutAsJsonAsync(requestURL, content);

            // API validation
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<TResponse>();
            return result;
        }
    }
}
