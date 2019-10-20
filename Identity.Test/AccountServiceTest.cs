using Xunit;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using CW.TestSystem.Identity.Infrastructure.Models.UserPresentation;
using Microsoft.AspNetCore.Identity;

namespace Identity.Test
{
    //TODO: Should be invistigate for most correct way to mock identity core classes
    public class AccountServiseTest
    {

        private readonly TestSystemDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        private DbContextOptions<TestSystemDbContext>  SetUpInMemoryDbOptions()
        {
           var options =  new DbContextOptionsBuilder<TestSystemDbContext>()
                    .UseInMemoryDatabase(databaseName: "FakeDb")
                    .Options;
            return options;
        }

        [Theory]
        [InlineData("example@gmail.com", "password123")]
        [InlineData("example@gmail.com", "password12")]
        [InlineData("example1@gmail.com", "password123")]
        public void TestSignInValidUser(string email, string password)
        {
            var loginUserModel = new LoginModel() { Email = email, Password = password };
            var options = SetUpInMemoryDbOptions();
            using (var context = new TestSystemDbContext(options))
            {
            }

        }

        [Fact]
        public void TestSignInInvalidUser()
        {
        }

        [Fact]
        public void TestSignUpValidUser()
        {
        }

        [Fact]
        public void TestSignUpInvalidUser()
        {

        }
    }
}
