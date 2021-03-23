using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace BlueBan.Aplication.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, Accountdto>()
            .ForMember(x => x.AccountId, ops => ops.MapFrom(x => x.AccountId))
            .ForMember(x => x.Number, ops => ops.MapFrom(x => x.Number))
            .ForMember(x => x.Value, ops => ops.MapFrom(x => x.Value))
            .ForMember(x => x.Type, ops => ops.MapFrom(x => x.Type))
            .ForMember(x => x.ClientId, ops => ops.MapFrom(x => x.ClientId)).ReverseMap();


            CreateMap<Client, Clientdto>()
           .ForMember(x => x.ClientId, ops => ops.MapFrom(x => x.ClientId))
           .ForMember(x => x.Name, ops => ops.MapFrom(x => x.Name))
           .ForMember(x => x.LastName, ops => ops.MapFrom(x => x.LastName)).ReverseMap();
        }
    }
}
