using System;
namespace FoodApp.Model
{
    public class UserRecipeInfo
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public Guid RecipeId { get; set; }

        public int RecipeCount { get; set; }
    }
}
