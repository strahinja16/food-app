using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Service.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<Recipe> GetRecipeById(Guid RecipeId);
        Task InsertRecipe(Recipe Recipe);
        Task DeleteRecipe(Guid RecipeId);
        Task UpdateRecipe(Recipe Recipe);
    }
}
