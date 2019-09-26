using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBoard.Data.Mapping
{
    using Data.Entities;
    using Data.ViewModels;
   internal class DataMappingProfile
        : Profile
    {
        public DataMappingProfile()
            : base("DataMapping")
        {
            CreateMap<CourseViewModel, Course>()
                .ConvertUsing((vm, c) =>
                {
                    return new Course(vm.Name);
                });
        }
    }
}
