using Api.Database.Core;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.V1.UserFactory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.V1.UserFactory
{
    public abstract class UserCreatorFactory
    {      
       
        public abstract IUserCreator Create(CreateUserRequest model);
    }
}
