using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;
using TestWebAPI.Domain.OutputModels;
using TestWebAPI.Repository.Context;

namespace TestWebAPI.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResModel>().ReverseMap();
            CreateMap<UserModel, User>()
                .ForMember(x=>x.UserId,opt=> opt.Ignore()).ReverseMap();
        }
    }
}
