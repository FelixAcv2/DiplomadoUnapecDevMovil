using DiplomadoShop.Constants;
using DiplomadoShop.Contract.DataService;
using DiplomadoShop.Contract.General;
using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TuPedidos.Core.Models;

namespace DiplomadoShop.Services.DataService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IApiService _apiService;
        private readonly ISettingsService _settingsService;

        public AuthenticationService(IApiService apiService, ISettingsService settingsService)
        {
            _apiService = apiService;
            _settingsService = settingsService;

        }
       
        public async Task<AuthenticationResponse> Register(string firstName, string lastName, string email, string userName, string password)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
               // Path = ApiConstants.RegisterEndpoint
            };

            AuthenticationRequest authenticationRequest = new AuthenticationRequest()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Password = password
            };

            return await _apiService.PostAsync<AuthenticationRequest, AuthenticationResponse>(builder.ToString(), authenticationRequest);
        }

        public  bool IsUserAuthenticated()
        {
            return !string.IsNullOrEmpty(_settingsService.UserIdSetting);
        }

        public async Task<AuthenticationResponse> Authenticate(string userName, string password)
        {
            //UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            //{
            //    Path = ApiConstants.AuthenticateEndpoint
            //};

            //AuthenticationRequest authenticationRequest = new AuthenticationRequest()
            //{
            //    UserName = userName,
            //    Password = password
            //};
            var _uri = $"api/authentication/authenticate/?username={userName}&password={password}";
            //var _uri = ApiConstants.BaseApiUrl + ApiConstants.AuthenticateEndpoint;
            var _authenticationRequest = await _apiService.GetAsync<AuthenticationResponse>(ApiConstants.BaseApiUrl + _uri);

            if (_authenticationRequest.IsAuthenticated && _authenticationRequest.User != null)
            {
                return _authenticationRequest;
            }
            else
            {

                _authenticationRequest.IsAuthenticated = false;
                return _authenticationRequest;
            }

        }
    }
}
