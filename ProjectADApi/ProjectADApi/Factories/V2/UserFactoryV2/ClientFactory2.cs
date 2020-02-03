using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Database.Core;
using Api.Database.Model;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.Core;
using ProjectADApi.Factories.Implementation;
using ProjectADApi.Factories.V1.UserFactory.Core;
using ProjectADApi.Factories.V1.UserFactory.Implementation;

namespace ProjectADApi.Factories.V2.UserFactoryV2
{
    public class ClientFactory2 : UserCreatorFactory2
    {
        //IRepository<Client> _clientRepository;

        //public ClientFactory(IRepository<Client> repository) => _clientRepository = repository;

        private readonly UserManager<UserLogin> _userManger;
        public ClientFactory2(UserManager<UserLogin> userManger) => _userManger = userManger;

        public override IUserCreator2 Create(CreateUserRequest model) => new ClientCreatorV2(_userManger);
        
    }
}
