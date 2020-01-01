using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Model;
using FoodApp.Service.Interfaces;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Schema.Query
{
    public class Query
    {
        public async Task<IReadOnlyList<User>> GetUsers([Service] IUserService userService)
        {
            return (IReadOnlyList<User>)await userService.GetUsers();
        }

        public async Task<IReadOnlyList<Recipe>> GetRecipes([Service] IRecipeService recipeService)
        {
            return (IReadOnlyList<Recipe>)await recipeService.GetRecipes();
        }
    }
}
