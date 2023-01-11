using AutoMapper;
using myTestProject.Authorization.Users;
using myTestProject.Domain;
using myTestProject.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myTestProject.Players.Dto
{
    public class PlayerMapProfile : Profile
    {
        public PlayerMapProfile()
        {
            CreateMap<PlayerDto, Player>();
        }

    }
}
