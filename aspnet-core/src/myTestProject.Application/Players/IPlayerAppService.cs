using Abp.Application.Services;
using myTestProject.Players.Dto;


namespace myTestProject.Players
{
    public interface IPlayerAppService : IAsyncCrudAppService<PlayerDto, long>
    {
    }
}
