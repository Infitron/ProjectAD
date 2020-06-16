using Api.Database.Core;
using Api.Database.Model;
using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Factories.V1.UserFactory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.V1.UserFactory.Implementation
{
    public class ClientCreator : IUserCreator
    {
        //IRepository<Client> _artisanRepository;
        //public ClientCreator(IRepository<Client> artisanRepository) => _artisanRepository = artisanRepository;
        readonly projectadContext _projectadContext;
        public ClientCreator() => _projectadContext = new projectadContext();


        async Task<CreateUserResponse> IUserCreator.CreateUser(CreateUserRequest model)
        {
            var userExist = _projectadContext.UserLogin.SingleOrDefault(x => x.Email.Equals(model.EmailAddress));

            if (userExist != null)
                return new CreateUserResponse
                {
                    Success = false,
                    ErrorMessage = "Email address already chosen by another user",
                    Token = "",
                    UserId = 0
                };

            UserLogin newLogin = new UserLogin
            {
                Email = model.EmailAddress,               
                UserName = model.UserName = model.UserName,
                RoleId = model.RoleId,
                CreationDate = DateTime.Now
            };

            await _projectadContext.UserLogin.AddAsync(newLogin);
            var isSaved = (await _projectadContext.SaveChangesAsync() > 0);

            if (isSaved)
            {
                //Client newClient = new Client
                //{
                //    EmailAddress = model.EmailAddress,
                //    PhoneNumber = "08012345678",
                //    FirstName = "Update firstname",
                //    LastName = "Update lastname",
                //    PicturePath = "update picture path",                  
                //    State = "update state",
                //    Address = "update address"

                    
                //};
                //_projectadContext.Client.Add(newClient);
                //await _projectadContext.SaveChangesAsync();

                return new CreateUserResponse
                {
                    Success = true,
                    UserId = newLogin.Id,
                    ErrorMessage = "",
                    Token = ""
                };
            }

            return new CreateUserResponse
            {
                Success = false,
                UserId = 0,
                ErrorMessage = "",
                Token = ""
            };

        }
    }
}


