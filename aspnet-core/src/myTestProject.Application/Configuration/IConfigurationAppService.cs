using System.Threading.Tasks;
using myTestProject.Configuration.Dto;

namespace myTestProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
