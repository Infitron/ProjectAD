﻿using Api.Database.Model;
using AutoMapper;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.MapperProfile
{
    public class ArtisanProfile : Profile
    {
        public ArtisanProfile()
        {
            CreateMap<Artisan, ArtisanResponse>()
                .ForMember(destination => destination.Booking, source => source.MapFrom(src => src.Booking))
                .ForMember(destination => destination.Projects, source => source.MapFrom(src => src.Projects))
                .ForMember(dest => dest.Gallary, source => source.MapFrom(src => src.Gallary))
                //.ForMember(dest => dest.AreaLocation, source => source.MapFrom(src => src.AreaLocation))
                .ForMember(dest => dest.Services, source => source.MapFrom(src => src.Services))
                .ForMember(dest => dest.PaymentHistory, source => source.MapFrom(src => src.PaymentHistory))
                .ForMember(dest => dest.ArtisanCategory, source => source.MapFrom(src => src.ArtisanCategory));

            CreateMap<ArtisanRequest, Artisan>()
                .ForMember(des => des.AreaLocation, act => act.Ignore())
                 .ForMember(des => des.ArtisanCategory, act => act.Ignore())
                  .ForMember(des => des.Booking, act => act.Ignore())
                   .ForMember(des => des.ArtisanServices, act => act.Ignore())
                    .ForMember(des => des.Projects, act => act.Ignore())
                     .ForMember(des => des.Gallary, act => act.Ignore())
                      .ForMember(des => des.Services, act => act.Ignore());
        }
    }

    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingResponse>();

        }
    }

    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Projects, ProjectResponse>();
        }
    }

    public class GallaryProfile : Profile
    {
        public GallaryProfile()
        {
            CreateMap<Gallary, GallaryResponse>();
        }


    }

    public class PaymentHistoryProfile : Profile
    {
        public PaymentHistoryProfile()
        {
            CreateMap<PaymentHistory, PaymentHistoryResponse>();
        }
    }

    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationResponse>();
        }
    }

    public class ArtisanCategoryProfile : Profile
    {
        public ArtisanCategoryProfile()
        {
            CreateMap<ArtisanCategories, ArtisanCategoryResponse>();
        }
    }

    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Services, ServiceResponse>();
        }
    }
}