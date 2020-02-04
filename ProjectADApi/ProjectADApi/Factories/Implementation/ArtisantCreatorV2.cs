﻿using Api.Database.Model;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Contract.V1.Response;
using ProjectADApi.Factories.Core;
using ProjectADApi.Factories.V1.UserFactory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories.Implementation
{
    public class ArtisantCreatorV2 : IUserCreator2
    {
        private readonly UserManager<UserLogin> _userManger;       

        public ArtisantCreatorV2(UserManager<UserLogin> userManger) {
           
            _userManger = userManger;
        }

        async Task<CreateUserResponse2> IUserCreator2.CreateUser(CreateUserRequest model)
        {
            // var userExist = _projectadContext.UserLogin.SingleOrDefault(x => x.EmailAddress.Equals(model.EmailAddress));

            var userExist = await _userManger.FindByEmailAsync(model.EmailAddress);

            if (userExist != null)
                return new CreateUserResponse2
                {
                    Success = false,
                    ErrorMessage = new[] {"A user already exist with the email entered"},
                    Token = "",
                    UserId = 0
                };

            UserLogin newLogin = new UserLogin
            {
                EmailAddress = model.EmailAddress,
                
                UserName = model.UserName = model.UserName,
                RoleId = model.RoleId,
                CreationDate = DateTime.Now, 
                Email = model.EmailAddress
            };

            var createUser = await _userManger.CreateAsync(newLogin, model.Password);

            if (!createUser.Succeeded)
            {
                return new CreateUserResponse2
                {
                    Success = false,
                    UserId = newLogin.Id,
                    ErrorMessage = createUser.Errors.Select(x => x.Description),
                    Token = ""
                };
            }         

            return new CreateUserResponse2
            {
                Success = true,
                UserId = model.RoleId,
                ErrorMessage = new string[0],
                Token = ""
            };
        }

    }
}