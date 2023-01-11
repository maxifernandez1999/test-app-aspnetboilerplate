using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using myTestProject.Domain;
using System.Threading.Tasks;
using System;

namespace myTestProject.Players.Dto
{
    [AutoMapFrom(typeof(Player))]
    public class PlayerDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

    }
}
