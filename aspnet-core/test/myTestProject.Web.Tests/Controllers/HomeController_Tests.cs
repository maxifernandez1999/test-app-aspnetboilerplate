using System.Threading.Tasks;
using myTestProject.Models.TokenAuth;
using myTestProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace myTestProject.Web.Tests.Controllers
{
    public class HomeController_Tests: myTestProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}