using System.Threading.Tasks;
using System.Collections.Generic;

namespace CW.TestSystem.Identity.Services.Interfaces
{
    using Infrastructure.Models.UserPresentation;

    public interface IAccountService
    {
        public Task<bool> SignUp(RegistrationModel registrationModel);
        public Task<(bool IsValid, string TokenBody, IList<string> Roles)> SignIn(LoginModel loginModel);
    }
}