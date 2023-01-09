using System.Threading.Tasks;
using Abp.Application.Services;
using myTestProject.Authorization.Accounts.Dto;

namespace myTestProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
