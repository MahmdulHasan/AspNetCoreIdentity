using PanelBoard.Membership.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace PanelBoard.Membership.Mapping
{
    using Entities;
    internal class MembershipMappingProfile
           : Profile
    {
       
        public MembershipMappingProfile()
            : base("Membership")
        {
            CreateMap<Role, AccountRole>()
                    .ConvertUsing((r, role) => {
                        var aRole = new AccountRole() { Role = r.Name };
                        switch (r.Name.ToLower())
                        {
                            case "administrator":
                                aRole.Id = 1;
                                break;
                            case "student":
                                aRole.Id = 2;
                                break;
                            case "teacher":
                                aRole.Id = 3;
                                break;
                            default:
                                throw new InvalidCastException("no such role supported");
                        }

                        return aRole;
                    });

            CreateMap<AccountRole, Role>()
                .ForMember(dst => dst.Name, options => options.MapFrom(ac => ac.Role));

            CreateMap<RegisterViewModel,User>()
                .ConvertUsing((vm,u) => {
                    return new User(vm.UserName);
            });


            CreateMap<RegisterViewModel, LoginViewModel>()
                .ForMember(dst => dst.Username, options => options.MapFrom(rvm => rvm.UserName))
                .ForMember(dst => dst.Password, options => options.MapFrom(rvm => rvm.Password));
        }
    }
}
