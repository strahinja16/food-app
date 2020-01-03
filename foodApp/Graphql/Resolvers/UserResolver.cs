using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using HotChocolate;

namespace FoodApp.Graphql.Resolvers
{
    public class UserResolver
    {
        public Task<IEnumerable<Recipe>> GetRecipes(User user, [Service]IRecipeRepository repository)
        {
            return repository.GetRecipesByUserId(user.Id);
        }
    }
}
