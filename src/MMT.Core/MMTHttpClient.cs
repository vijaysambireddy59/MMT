using System;
using System.Net;
using MMT.Common.CustomExceptions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MMT.Common.Models;

namespace MMT.Core
{
    public class MMTHttpClient : IMMTHttpClient
    {
        private readonly ILogger<MMTHttpClient> _logger;
        private readonly HttpClient _httpClient;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public MMTHttpClient(IHttpClientFactory clientFactory, IOptions<UserAPISettings> userApiSettings, ILogger<MMTHttpClient> logger)
        {
            _logger = logger;
            _httpClient = clientFactory.CreateClient();
            APISettings apiSettings = userApiSettings.Value;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.CancelAfter(apiSettings.Timeout);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                using var response = await _httpClient.GetAsync(url, _cancellationTokenSource.Token);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode == false)
                    throw new APIException("API Error", (int)response.StatusCode);


                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (OperationCanceledException)
            {
                _logger.LogError("TimeoutException");
                throw new APIException("TimeoutException", (int)HttpStatusCode.RequestTimeout);
            }

        }
    }
}
