using System.Threading.Tasks;
using Abp.Application.Services;
using myTestProject.Sessions.Dto;

namespace myTestProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
