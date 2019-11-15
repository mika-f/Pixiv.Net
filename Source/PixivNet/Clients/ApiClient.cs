using System;
using System.Collections.Generic;
using System.IO;
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
            var (isRequiredAuthentication, isRequiredReferrer) = CheckCallerMethodAttributes(caller);
            return (await Client.GetAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, isRequiredReferrer, parameters).Stay()).ToObject<T>();
        }

        protected async Task<JObject> GetAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var (isRequiredAuthentication, isRequiredReferrer) = CheckCallerMethodAttributes(caller);
            return await Client.GetAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, isRequiredReferrer, parameters).Stay();
        }

        protected async Task<Stream> GetAsyncAsStream(Uri uri, [CallerMemberName] string? caller = null)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            var (isRequiredAuthentication, isRequiredReferrer) = CheckCallerMethodAttributes(caller);
            return await Client.GetAsyncAsStream(uri.ToString(), isRequiredAuthentication, isRequiredReferrer).Stay();
        }

        protected async Task<T> PostAsync<T>(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var (isRequiredAuthentication, isRequiredReferrer) = CheckCallerMethodAttributes(caller);
            return (await Client.PostAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, isRequiredReferrer, parameters).Stay()).ToObject<T>();
        }

        protected async Task<JObject> PostAsync(string endpoint = "", List<KeyValuePair<string, object>>? parameters = null, [CallerMemberName] string? caller = null)
        {
            var (isRequiredAuthentication, isRequiredReferrer) = CheckCallerMethodAttributes(caller);
            return await Client.PostAsync($"https://{_host}{_base}{endpoint}", isRequiredAuthentication, isRequiredReferrer, parameters).Stay();
        }

        private (bool, bool) CheckCallerMethodAttributes(string? caller)
        {
            var isRequiredAuthentication = false;
            var isRequiredReferrer = false;
            if (!string.IsNullOrWhiteSpace(caller))
            {
                var method = GetType().GetMethod(caller, BindingFlags.Instance | BindingFlags.Public);
                isRequiredAuthentication = method?.GetCustomAttribute<RequiredAuthenticationAttribute>() != null;
                isRequiredReferrer = method?.GetCustomAttribute<RequiredReferrerAttribute>() != null;
            }

            return (isRequiredAuthentication, isRequiredReferrer);
        }
    }
}