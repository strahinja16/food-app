using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApp.Model;

namespace FoodApp.Repository.Interfaces
{
    public interface ITagRepository : IRepository
    {
        Task<IEnumerable<Tag>> GetTags();
        Task<IEnumerable<Tag>> GetTagsByRecipeId(Guid RecipeId);
        Task<IEnumerable<Tag>> GetTagsByNames(List<string> tagNames);
        IQueryable<Tag> GetTagsAsIQueryable();
        Task<Tag> GetTagById(Guid TagId);
        Task<Tag> GetTagByName(string Name);
        Task InsertTag(Tag Tag);
        Task DeleteTag(Guid TagId);
        Task UpdateTag(Tag Tag);
    }
}
