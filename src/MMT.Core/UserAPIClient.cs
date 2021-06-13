using Microsoft.Extensions.Options;
using MMT.Common.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace MMT.Core
{
    public class UserAPIClient : IUserAPIClient
    {
        private readonly IMMTHttpClient _httpClient;
        private readonly ILogger<UserAPIClient> _logger;
        private readonly UserAPISettings _userApiSettings;

        public UserAPIClient(IMMTHttpClient httpClient, IOptions<UserAPISettings> userApiSettings, ILogger<UserAPIClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _userApiSettings = userApiSettings.Value;
        }

        public async Task<CustomerFullDetails> Get(string email)
        {
            _logger.LogInformation($"UserAPICLient [Get] {email}");
            var url = $"{_userApiSettings.BaseUrl}{_userApiSettings.UserDetails}?code={_userApiSettings.APIKey}&email={email}";
            return await _httpClient
                .GetAsync<CustomerFullDetails>(url);
        }
    }
}
