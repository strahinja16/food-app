using System;
using System.Threading.Tasks;
using FoodApp.Graphql.Input.Recipe;
using FoodApp.Graphql.Input.User;
using FoodApp.Model;
using HotChocolate.Subscriptions;

namespace FoodApp.Services.Interfaces
{
    public interface IMutationService
    {
        Task<User> InsertUser(InsertUserInput userInput);

        Task<Recipe> InsertRecipe(InsertRecipeInput recipeInput, IEventSender eventSender);

        Task<User> UpdateUser(UpdateUserInput updateUserInput);
    }
}
