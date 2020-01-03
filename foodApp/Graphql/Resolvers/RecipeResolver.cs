using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;
using FoodApp.Repository.Interfaces;
using HotChocolate;

namespace FoodApp.Graphql.Resolvers
{
    public class RecipeResolver
    {
        public Task<IEnumerable<Tag>> GetTags(Recipe recipe, [Service]ITagRepository repository)
        {
            return repository.GetTagsByRecipeId(recipe.Id);
        }
    }
}
