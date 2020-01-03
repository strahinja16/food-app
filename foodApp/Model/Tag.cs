using System;
using System.Collections.Generic;

namespace FoodApp.Model
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<RecipeTag> RecipeTags { get; set; }
    }
}
