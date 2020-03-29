using Api.Database.Model;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.Core;
using ProjectADApi.Factories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.V2.UserFactoryV2
{
    public class AdminFactory2 : UserCreatorFactory2
    {
        private readonly UserManager<UserLogin> _userManger;
        public AdminFactory2(UserManager<UserLogin> userManger) => _userManger = userManger;



        public override IUserCreator2 Create(CreateUserRequest model) => new AdminCreator(_userManger);
    }
}
