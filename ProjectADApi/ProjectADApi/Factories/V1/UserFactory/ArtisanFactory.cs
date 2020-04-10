using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.V1.UserFactory.Core;
using ProjectADApi.Factories.V1.UserFactory.Implementation;

namespace ProjectADApi.Factories.V1.UserFactory
{
    public class ArtisanFactory : UserCreatorFactory
    {
        //IRepository<Artisan> _artisanRepository;

        //public ArtisanFactory(IRepository<Artisan> repository) => _artisanRepository = repository;
        
       
        public override IUserCreator Create(CreateUserRequest model) => new ArtisanCreator();
        
    }

   
}
