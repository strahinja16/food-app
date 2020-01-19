using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.DbContexts;
using FoodApp.Graphql.Input.Recipe;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Graphql.Query
{
    public class Query
    {
        public async Task<IReadOnlyList<User>> GetUsers([Service] IUserRepository userRepository)
        {
            return (IReadOnlyList<User>)await userRepository.GetUsers();
        }

        public async Task<Recipe> GetRecipe([Service] IRecipeRepository recipeRepository, GetRecipeInput getRecipeInput)
        {
            return await recipeRepository.GetRecipeById(getRecipeInput.RecipeId);
        }

        public IQueryable<Tag> GetTags([Service] ITagRepository tagRepository)
        {
            return tagRepository.GetTagsAsIQueryable();
        }   
    }
}
