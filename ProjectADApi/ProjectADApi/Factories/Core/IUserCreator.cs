using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.V1.UserFactory.Core
{
    public interface IUserCreator
    {
         Task<CreateUserResponse> CreateUser(CreateUserRequest model);
    }
}
