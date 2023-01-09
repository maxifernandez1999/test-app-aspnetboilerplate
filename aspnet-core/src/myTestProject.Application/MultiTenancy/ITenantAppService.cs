using Abp.Application.Services;
using myTestProject.MultiTenancy.Dto;

namespace myTestProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

