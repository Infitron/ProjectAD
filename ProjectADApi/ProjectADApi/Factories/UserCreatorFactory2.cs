using Api.Database.Model;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories
{
    public abstract class UserCreatorFactory2
    {        
        public abstract IUserCreator2 Create(CreateUserRequest model);
    }
}
