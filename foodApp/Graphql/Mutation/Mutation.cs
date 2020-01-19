using System;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Graphql.Input.User;
using HotChocolate;
using FoodApp.Repository.Interfaces;
using FoodApp.Services;
using FoodApp.Graphql.Input.Recipe;
using FoodApp.Services.Interfaces;
using HotChocolate.Subscriptions;

namespace FoodApp.Graphql.Mutation
{
    public class Mutation
    {
        public async Task<User> InsertUser([Service] IMutationService mutationService, InsertUserInput userInput)
        {
            return await mutationService.InsertUser(userInput);
        }

        public async Task<Recipe> InsertRecipe(
            [Service] IMutationService mutationService,
            [Service] IEventSender eventSender,
            InsertRecipeInput recipeInput)
        {
            return await mutationService.InsertRecipe(recipeInput, eventSender);
        }

        public async Task<bool> DeleteUser([Service] IUserRepository userRepository, DeleteUserInput deleteUserInput)
        {
            await userRepository.DeleteUser(deleteUserInput.UserId);
            return true;
        }

        public async Task<User> UpdateUser([Service] IMutationService mutationService, UpdateUserInput updateUserInput)
        {
            return await mutationService.UpdateUser(updateUserInput);
        }
    }
}
