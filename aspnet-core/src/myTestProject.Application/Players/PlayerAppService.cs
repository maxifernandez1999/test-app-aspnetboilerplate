using Abp.Application.Services.Dto;
using Abp.Authorization;

using myTestProject.Authorization.Users;
using myTestProject.Authorization;
using myTestProject.Users.Dto;
using System;
using myTestProject.Players.Dto;
using System.Threading.Tasks;
using myTestProject.Roles.Dto;
using Abp.Application.Services;
using myTestProject.Domain;
using myTestProject.Users;
using Abp.Domain.Repositories;

namespace myTestProject.Players
{
    [AbpAuthorize(PermissionNames.Pages_Players)]
    public class PlayerAppService : AsyncCrudAppService<Player, PlayerDto, long>, IPlayerAppService
    {
        public PlayerAppService(IRepository<Player, long> repository) : base(repository)
        {
        }
    }
}
