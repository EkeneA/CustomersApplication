namespace CustomersApplication.Core.WebApi.Interfaces
{
    public interface IWebApiService
    {
        Task<TResponse> DeleteAsync<TResponse>(string requestURL);
        Task<TResponse> GetAsync<TResponse>(string requestURL);
        Task<TResponse> PatchAsync<TRequest, TResponse>(string requestURL, TRequest content);
        Task<TResponse> PostAsync<TRequest, TResponse>(string requestURL, TRequest content);
        Task<TResponse> PutAsync<TRequest, TResponse>(string requestURL, TRequest content);
    }
}
