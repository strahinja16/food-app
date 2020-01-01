using System;
namespace FoodApp.Model
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public int PrepTime { get; set; }

        public int Kcal { get; set; }

        public int Carbs { get; set; }

        public int Fat { get; set; }

        public int Protein { get; set; }
    }
}
