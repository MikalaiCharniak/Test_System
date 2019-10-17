using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace CW.TestSystem.Identity.Infrastructure.Extensions
{
    using Model.CoreEntities;
    public static class IdentityManager
    {
        public static async Task<SignInResult> PasswordEmailSignInAsync(this SignInManager<User> signInManager, 
            UserManager<User> userManager, string email, string password,
            bool isPersistent = false, bool shouldLockout = false)
        {  
            var user = await userManager.FindByEmailAsync(email);
            var result = await signInManager.PasswordSignInAsync(user.UserName, password, isPersistent, shouldLockout);
            return result;
        }
    }
}