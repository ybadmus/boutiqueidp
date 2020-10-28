using API.Models;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<spSelectCategory>> ListAllCategoriesAsync();
        Task<IEnumerable<spSelectCategory>> ListCategoryByIdAsync(Guid uniId);
        Task AddCategoryAsync(string CategoryName, string Description,
            string PhotoImage, Guid? UserId);
        Task UpdateCategoryAsync(Guid uniId, string CategoryName, string Description,
            string PhotoImage, Guid? UserId);
        Task DeleteCategoryAsync(tblCategory entity);
        tblCategory GetCategory(Guid uniId);
        bool Save();
        void Commit();
    }
}
