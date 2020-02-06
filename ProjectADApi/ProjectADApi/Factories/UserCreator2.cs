using Api.Database.Model;
using Microsoft.AspNetCore.Identity;
using ProjectADApi.ApiConfig;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.Core;
using ProjectADApi.Factories.V1.UserFactory;
using ProjectADApi.Factories.V1.UserFactory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories
{
    public class UserCreator2
    {
        public Dictionary<AppUsers, UserCreatorFactory2> AppUserCreatorFactory;
        UserManager<UserLogin> _userManager;

        public UserCreator2(UserManager<UserLogin> userManager)
        {
            _userManager = userManager;
            AppUserCreatorFactory = new Dictionary<AppUsers, UserCreatorFactory2>();
            //{
            //    { AppUsers.Artisan, new ArtisanFactory()},
            //    {AppUsers.Client, new ClientFactory() }
            //};

            foreach (AppUsers user in Enum.GetValues(typeof(AppUsers)))
            {
                var factory = (UserCreatorFactory2)Activator.CreateInstance(Type.GetType("ProjectADApi.Factories.V2.UserFactoryV2." + Enum.GetName(typeof(AppUsers), user) + "Factory2"),  _userManager);
                AppUserCreatorFactory.Add(user, factory);
            }
        }

        public IUserCreator2 ExecuteCreation(AppUsers AppUser, CreateUserRequest model) => AppUserCreatorFactory[AppUser].Create(model);
    }
}
