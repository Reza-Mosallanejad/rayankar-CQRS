using AutoMapper;
using CRUDTest.Domain.DTOs;
using CRUDTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
