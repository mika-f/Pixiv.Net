using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using Pixiv.Attributes;
using Pixiv.Extensions;

namespace Pixiv.Clients
{
    public class ApiClient
    {
        private readonly string _base;
        private readonly string _host;
        protected PixivClient Client { get; }

        protected ApiClient(PixivClient client, string @base, string host = "app-api.pixiv.net")
        {
            Client = client;
            _base = @base;
            _host = host;
        }

        protected async Task<T> GetAsync<T>(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var isRequiredAuthentication = false;
            if (!string.IsNullOrWhiteSpace(caller))
                isRequiredAuthentication = GetType().GetMethod(caller, BindingFlags.Instance | BindingFlags.Public)?.GetCustomAttribute<RequiredAuthenticationAttribute>() != null;

            return (await Client.GetAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, parameters).Stay()).ToObject<T>();
        }

        protected async Task<JObject> GetAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var isRequiredAuthentication = false;
            if (!string.IsNullOrWhiteSpace(caller))
                isRequiredAuthentication = GetType().GetMethod(caller, BindingFlags.Instance | BindingFlags.Public)?.GetCustomAttribute<RequiredAuthenticationAttribute>() != null;

            return await Client.GetAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, parameters).Stay();
        }

        protected async Task<T> PostAsync<T>(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var isRequiredAuthentication = false;
            if (!string.IsNullOrWhiteSpace(caller))
                isRequiredAuthentication = GetType().GetMethod(caller, BindingFlags.Instance | BindingFlags.Public)?.GetCustomAttribute<RequiredAuthenticationAttribute>() != null;

            return (await Client.PostAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, parameters).Stay()).ToObject<T>();
        }

        protected async Task<JObject> PostAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var isRequiredAuthentication = false;
            if (!string.IsNullOrWhiteSpace(caller))
                isRequiredAuthentication = GetType().GetMethod(caller, BindingFlags.Instance | BindingFlags.Public)?.GetCustomAttribute<RequiredAuthenticationAttribute>() != null;

            return await Client.PostAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, parameters).Stay();
        }
    }
}