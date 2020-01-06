using System;
using System.Collections.Generic;
using FoodApp.Graphql.Input.Tag;

namespace FoodApp.Graphql.Input.Recipe
{
    public class InsertRecipeInput
    {
        public Guid UserId { get; set; }

        public List<InsertTagInput> Tags { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public int PrepTime { get; set; }

        public int Kcal { get; set; }

        public int Carbs { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }
    }
}
