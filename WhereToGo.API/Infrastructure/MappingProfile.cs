using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WhereToGo.BL.Models;
using WhereToGo.DAL.Domain;
using WhereToGo.BL.Models.Places;

namespace WhereToGo.API.Infrastructure
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Place, PlaceModel>();
            CreateMap<PlaceModel, Place>();

            CreateMap<TagModel, Tag>();
            CreateMap<Tag, TagModel>();
        }
    }
}
