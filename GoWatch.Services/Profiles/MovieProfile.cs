using AutoMapper;
using GoWatch.Data.Entities;
using GoWatch.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoWatch.Services.Profiles
{
    public class MovieProfile : Profile
    {

        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
