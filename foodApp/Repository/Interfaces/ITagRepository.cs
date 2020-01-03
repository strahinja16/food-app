using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Repository.Interfaces
{
    public interface ITagRepository : IRepository
    {
        Task<IEnumerable<Tag>> GetTags();
        Task<IEnumerable<Tag>> GetTagsByRecipeId(Guid RecipeId);
        Task<Tag> GetTagById(Guid TagId);
        Task InsertTag(Tag Tag);
        Task DeleteTag(Guid TagId);
        Task UpdateTag(Tag Tag);
    }
}
