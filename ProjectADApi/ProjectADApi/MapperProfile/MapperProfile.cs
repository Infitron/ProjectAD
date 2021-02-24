using Api.Database.Model;
using AutoMapper;
using Newtonsoft.Json;
using ProjectADApi.Controllers.V2.Contract.Request;
using ProjectADApi.Controllers.V2.Contract.Response;
using ProjectADApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Artisan, ArtisanResponse>()
                //.ForMember(destination => destination.Booking, source => source.MapFrom(src => src.Booking))
                //.ForMember(destination => destination.Projects, source => source.MapFrom(src => src.Projects))
                //.ForMember(dest => dest.Gallary, source => source.MapFrom(src => src.Gallary))
                //.ForMember(dest => dest.AreaLocation, source => source.MapFrom(src => src.AreaLocation))
                //// .ForMember(dest => dest.Services, source => source.MapFrom(src => src.Services))
                //.ForMember(dest => dest.PaymentHistory, source => source.MapFrom(src => src.PaymentHistory))
                //.ForMember(dest => dest.ArtisanCategory, source => source.MapFrom(src => src.ArtisanCategory))
                ;

            CreateMap<ArtisanRequest, Artisan>()
                .ForMember(des => des.AreaLocation, act => act.Ignore())
                 .ForMember(des => des.ArtisanCategory, act => act.Ignore());
                  //.ForMember(des => des.Booking, act => act.Ignore())
                  // .ForMember(des => des.ArtisanServices, act => act.Ignore())
                  //  .ForMember(des => des.Projects, act => act.Ignore())
                  //   .ForMember(des => des.Gallary, act => act.Ignore())
                  //    .ForMember(des => des.Services, act => act.Ignore())
        }
    }

    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingResponse>(MemberList.Source);
        }
    }

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientResponse>(MemberList.Source);
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
            CreateMap<Location, LocationResponse>()
                //.ForMember(destination => destination.Artisan, source => source.MapFrom(src => src.Artisan))
                .ForMember(destination => destination.Services, source => source.MapFrom(src => src.Services));

            CreateMap<LocationResponse, Location>();
        }
    }

    public class ArtisanCategoryProfile : Profile
    {
        public ArtisanCategoryProfile()
        {
            CreateMap<ArtisanCategories, CategoryResponse>();
        }
    }

    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Services, ServiceResponse>();

            CreateMap<ServiceRequest, Services>();
        }
    }

    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<ArtisanSubCategory, SubCategoryResponse>()
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.SubCategories))
                .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Descr));

            CreateMap<SubCategoryRequest, ArtisanSubCategory>()
                .ForMember(destination => destination.SubCategories, source => source.MapFrom(src => src.Name))
                .ForMember(destination => destination.Descr, source => source.MapFrom(src => src.Description))
                .ForMember(destination => destination.CategoryId, source => source.MapFrom(src => src.CategoryId));
        }
    }

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ArtisanCategories, CategoryResponse>();
            CreateMap<CatergoryRequest, ArtisanCategories>();
        }
    }

    public class ArtisanServiceProfile : Profile
    {
        public ArtisanServiceProfile()
        {
            CreateMap<ArtisanServices, ArtisanServiceResponse>();
            CreateMap<ArtisanServiceRequest, ArtisanServices>();
        }
    }

    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<State, StateResponse>()
                .ForMember(destination => destination.LocalGovernment, source => source.MapFrom(src => src.Lga));
            CreateMap<ArtisanServiceRequest, ArtisanServices>();
        }
    }

    public class ComplaintProfile : Profile
    {
        public ComplaintProfile()
        {
            CreateMap<Complaint, ComplaintResponse>()
                .ForMember(destination => destination.ArtisanId, source => source.MapFrom(src => src.EmailId));

            CreateMap<ComplaintRequest, Complaint>()
                .ForMember(destination => destination.EmailId, source => source.MapFrom(src => src.ArtisanId)); ;
        }
    }

    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteResponse>()
                .ForMember(destination => destination.Item, source => source.MapFrom(src => JsonConvert.DeserializeObject<List<QuoteItem>>(src.Item)))
                .ForMember(destination => destination.QuoteStatusId, source => source.MapFrom(src => src.QuoteStatusId));

            CreateMap<QuoteRequest, Quote>()
                .ForMember(destination => destination.Item, source => source.MapFrom(src => JsonConvert.SerializeObject(src.Item)));

            CreateMap<QuoteRequestUpdate, Quote>()
               .ForMember(destination => destination.Item, source => source.MapFrom(src => JsonConvert.SerializeObject(src.Item)));
        }
    }
}
