using System;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Schema.Input.User;
using FoodApp.Service.Interfaces;
using HotChocolate;

namespace FoodApp.Schema.Mutation
{
    public class Mutation
    {
        public async Task<User> InsertUser([Service] IUserService userService, InsertUserInput userInput)
        {
            var user = new User()
            {
                Name = userInput.Name
            };

            await userService.InsertUser(user);

            return user;
        }
    }
}
