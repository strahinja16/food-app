using System;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Graphql.Input.User;
using HotChocolate;
using FoodApp.Repository.Interfaces;

namespace FoodApp.Graphql.Mutation
{
    public class Mutation
    {
        public async Task<User> InsertUser([Service] IUserRepository userRepository, InsertUserInput userInput)
        {
            var user = new User()
            {
                Name = userInput.Name
            };

            await userRepository.InsertUser(user);

            return user;
        }
    }
}
