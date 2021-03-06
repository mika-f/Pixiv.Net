﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Pixiv.Attributes;
using Pixiv.Extensions;
using Pixiv.Models;

namespace Pixiv.Clients.Auth
{
    public class AuthenticationClient : ApiClient
    {
        internal AuthenticationClient(PixivClient client) : base(client, "/auth", "oauth.secure.pixiv.net") { }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<Credential> LoginAsync(string username, string password, string? deviceToken = null)
        {
            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(nameof(username), username),
                new KeyValuePair<string, object>(nameof(password), password),
                new KeyValuePair<string, object>("client_id", Client.ClientId),
                new KeyValuePair<string, object>("client_secret", Client.ClientSecret),
                new KeyValuePair<string, object>("get_secure_url", true),
                new KeyValuePair<string, object>("grant_type", "password"),
                new KeyValuePair<string, object>("include_policy", true)
            };
            if (!string.IsNullOrWhiteSpace(deviceToken))
                parameters.Add(new KeyValuePair<string, object>("device_token", deviceToken));

            var response = await PostAsync("/token", parameters).Stay();
            var credential = response["response"]!.ToObject<Credential>()!;
            Client.AccessToken = credential.AccessToken;
            Client.RefreshToken = credential.RefreshToken;

            return credential;
        }

        [ApiVersion]
        [MarkedAs("7.7.7")]
        public async Task<Credential> RefreshAsync()
        {
            if (string.IsNullOrWhiteSpace(Client.RefreshToken))
                throw new InvalidOperationException();

            var parameters = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("client_id", Client.ClientId),
                new KeyValuePair<string, object>("client_secret", Client.ClientSecret),
                new KeyValuePair<string, object>("get_secure_url", true),
                new KeyValuePair<string, object>("grant_type", "refresh_token"),
                new KeyValuePair<string, object>("include_policy", true),
                new KeyValuePair<string, object>("refresh_token", Client.RefreshToken)
            };

            var response = await PostAsync("/token", parameters).Stay();
            var credential = response["response"]!.ToObject<Credential>()!;
            Client.AccessToken = credential.AccessToken;
            Client.RefreshToken = credential.RefreshToken;

            return credential;
        }
    }
}