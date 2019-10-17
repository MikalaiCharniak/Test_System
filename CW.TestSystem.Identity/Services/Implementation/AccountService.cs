using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CW.TestSystem.Identity.Services.Implementation
{
    using CommonLogic.Environment;
    using Model.CoreEntities;
    using Model.ModelConstants;
    using DataProvider.DbInfrastracture;
    using Infrastructure.Models.UserPresentation;
    using Identity.Infrastructure.Extensions;
    using Interfaces;

    public class AccountService : IAccountService
    {
        private readonly TestSystemDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountService(TestSystemDbContext context, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool IsValid, string TokenBody, IList<string> Roles)> SignIn(LoginModel loginModel)
        {
            try
            {
                var isLogin = await _signInManager.PasswordEmailSignInAsync(_userManager, loginModel.Email, loginModel.Password);
                if (!(isLogin == SignInResult.Success)) return (IsValid: false, TokenBody: null, Roles: null);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginModel.Email);
                var userRoles = await _userManager.GetRolesAsync(user);
                var token = GenerateAccessToken(user, userRoles);
                return (IsValid: true, TokenBody: token, Roles: userRoles);
            }
            catch (Exception ex)
            { 
            
            }
            return (IsValid: false, TokenBody: null, Roles: null);
        }

        public async Task<bool> SignUp(RegistrationModel registrationModel)
        {
            try
            {
                User appUser = new User() { Email = registrationModel.Email, UserName = registrationModel.Name };
                IdentityResult isUserCreated = await _userManager.CreateAsync(appUser, registrationModel.Password);
                IdentityResult isRoleCreated = await _userManager.AddToRoleAsync(appUser, UserRoles.TestableUser);
                return isUserCreated == IdentityResult.Success && isRoleCreated == IdentityResult.Success ? true : false;
            }
            catch (Exception ex)
            { 
            
            }
            return false;
        }

        private string GenerateAccessToken(User user, IList<string> roles)
        {
            var configuration = Settings.GetConfiguration();
            var claims = SetupUserClaims(user, roles);
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = configuration["JWT:Issuer"],
                Audience = configuration["JWT:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims),

            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private IEnumerable<Claim> SetupUserClaims(User user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email",user.Email)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}