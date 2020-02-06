using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.Core;
using ProjectADApi.Factories.Implementation;
using ProjectADApi.Factories.V1.UserFactory.Core;


namespace ProjectADApi.Factories.V2.UserFactoryV2
{
    public class ArtisanFactory2 : UserCreatorFactory2
    {
        //IRepository<Artisan> _artisanRepository;

        //public ArtisanFactory(IRepository<Artisan> repository) => _artisanRepository = repository;

        private readonly  UserManager<UserLogin> _userManger;
        public ArtisanFactory2(UserManager<UserLogin> userManger) => _userManger = userManger; 
      


        public override IUserCreator2 Create(CreateUserRequest model) => new ArtisantCreatorV2(_userManger);
    }

    
}
