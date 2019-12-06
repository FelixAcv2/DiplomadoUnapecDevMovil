using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TuPedidos.Core.Models;

namespace DiplomadoShop.Contract.DataService
{
   public  interface IAuthenticationService
    {
        Task<AuthenticationResponse>Register(string firstName, string lastName, string email, string userName,string password);
        Task<AuthenticationResponse> Authenticate(string userName, string password);
        bool IsUserAuthenticated();
    }
}
