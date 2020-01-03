using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Repository.Interfaces
{
    public interface IRecipeRepository: IRepository
    {
        Task<IEnumerable<Recipe>> GetRecipes();
        Task<IEnumerable<Recipe>> GetRecipesByUserId(Guid UserId);
        Task<Recipe> GetRecipeById(Guid RecipeId);
        Task InsertRecipe(Recipe Recipe);
        Task DeleteRecipe(Guid RecipeId);
        Task UpdateRecipe(Recipe Recipe);
    }
}
