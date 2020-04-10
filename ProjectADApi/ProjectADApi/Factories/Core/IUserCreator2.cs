using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.Core
{
   public interface IUserCreator2
    {
        Task<CreateUserResponse2> CreateUser(CreateUserRequest model);
    }
}
