using ProjectADApi.Contract.Request;
using ProjectADApi.Contract.V1.Request;
using ProjectADApi.Factories.V1.UserFactory;
using ProjectADApi.Factories.V1.UserFactory.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Factories
{
    public class UserCreator
    {
        public Dictionary<AppUsers, UserCreatorFactory> AppUserCreatorFactory;

        public UserCreator()
        {
            AppUserCreatorFactory = new Dictionary<AppUsers, UserCreatorFactory>();
            //{
            //    { AppUsers.Artisan, new ArtisanFactory()},
            //    {AppUsers.Client, new ClientFactory() }
            //};

            foreach(AppUsers user in Enum.GetValues(typeof(AppUsers)))
            {
                var factory = (UserCreatorFactory)Activator.CreateInstance(Type.GetType("ProjectADApi.Factories.V1.UserFactory." + Enum.GetName(typeof(AppUsers), user) + "Factory"));
                AppUserCreatorFactory.Add(user, factory);
            }
        }

        public IUserCreator ExecuteCreation(AppUsers AppUser, CreateUserRequest model) => AppUserCreatorFactory[AppUser].Create(model);
    }
}
