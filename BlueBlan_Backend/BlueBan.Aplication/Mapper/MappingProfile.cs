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
            .ForMember(x => x.accountid, ops => ops.MapFrom(x => x.AccountId))
            .ForMember(x => x.number, ops => ops.MapFrom(x => x.Number))
            .ForMember(x => x.valueinit, ops => ops.MapFrom(x => x.ValueInit))
            .ForMember(x => x.valuecurrent, ops => ops.MapFrom(x => x.Valuecurrent))
            .ForMember(x => x.type, ops => ops.MapFrom(x => x.Type))
            .ForMember(x => x.state, ops => ops.MapFrom(x => x.State))
            .ForMember(x => x.clientid, ops => ops.MapFrom(x => x.ClientId)).ReverseMap();


            CreateMap<Client, Clientdto>()
           .ForMember(x => x.clientid, ops => ops.MapFrom(x => x.ClientId))
           .ForMember(x => x.name, ops => ops.MapFrom(x => x.Name))
           .ForMember(x => x.lastname, ops => ops.MapFrom(x => x.LastName)).ReverseMap();

            CreateMap<AccountMove, AccountMovedto>()
            .ForMember(x => x.accountId, ops => ops.MapFrom(x => x.AccountId))
            .ForMember(x => x.datemove, ops => ops.MapFrom(x => x.DateMove))
            .ForMember(x => x.value, ops => ops.MapFrom(x => x.Value))
            .ForMember(x => x.typemove, ops => ops.MapFrom(x => x.TypeMove)).ReverseMap();

            CreateMap<User, Userdto>()
            .ForMember(x => x.username, ops => ops.MapFrom(x => x.UserName))
            .ForMember(x => x.email, ops => ops.MapFrom(x => x.Email))
            .ForMember(x => x.password, ops => ops.MapFrom(x => x.PasswordHash))
            .ForMember(x => x.name, ops => ops.MapFrom(x => x.Name)).ReverseMap();
        }
    }
}
