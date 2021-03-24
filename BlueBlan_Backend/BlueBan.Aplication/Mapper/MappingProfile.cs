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
            .ForMember(x => x.ValueInit, ops => ops.MapFrom(x => x.ValueInit))
            .ForMember(x => x.Valuecurrent, ops => ops.MapFrom(x => x.Valuecurrent))
            .ForMember(x => x.Type, ops => ops.MapFrom(x => x.Type))
            .ForMember(x => x.State, ops => ops.MapFrom(x => x.State))
            .ForMember(x => x.ClientId, ops => ops.MapFrom(x => x.ClientId)).ReverseMap();


            CreateMap<Client, Clientdto>()
           .ForMember(x => x.ClientId, ops => ops.MapFrom(x => x.ClientId))
           .ForMember(x => x.Name, ops => ops.MapFrom(x => x.Name))
           .ForMember(x => x.LastName, ops => ops.MapFrom(x => x.LastName)).ReverseMap();

            CreateMap<AccountMove, AccountMovedto>()
             .ForMember(x => x.AccountId, ops => ops.MapFrom(x => x.AccountId))
             .ForMember(x => x.DateMove, ops => ops.MapFrom(x => x.DateMove))
             .ForMember(x => x.Value, ops => ops.MapFrom(x => x.Value))
             .ForMember(x => x.TypeMove, ops => ops.MapFrom(x => x.TypeMove)).ReverseMap();
        }
    }
}
