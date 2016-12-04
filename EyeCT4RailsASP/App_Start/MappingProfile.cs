using AutoMapper;
using EyeCT4RailsASP.Dtos;
using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EyeCT4RailsASP.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			Mapper.CreateMap<Tram, TramDto>();
			Mapper.CreateMap<TramDto, Tram>();
			Mapper.CreateMap<Track, TrackDto>();
			Mapper.CreateMap<TrackDto, Track>();
		}
	}
}