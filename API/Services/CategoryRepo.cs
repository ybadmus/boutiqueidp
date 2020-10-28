using API.Helpers;
using API.Models;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CategoryRepo : ICategoryRepo
    {
        private BoutiqueContext _context;

        public CategoryRepo(BoutiqueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddCategoryAsync(string CategoryName, string Description, string PhotoImage, Guid? UserId)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "spInsertCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                cmdObj.Parameters.Add(new SqlParameter("@Description", Description));
                cmdObj.Parameters.Add(new SqlParameter("@PhotoImage", PhotoImage));
                cmdObj.Parameters.Add(new SqlParameter("@UserId", UserId));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task DeleteCategoryAsync(tblCategory entity)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "spDeleteCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryId", entity.CategoryId));

                await cmdObj.ExecuteScalarAsync();
            }
        }

        public tblCategory GetCategory(Guid uniId)
        {
            return _context.tblCategory.FirstOrDefault(c => c.CategoryId == uniId);
        }

        public async Task<IEnumerable<spSelectCategory>> ListAllCategoriesAsync()
        {
            List<spSelectCategory> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "spSelectCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                //cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<spSelectCategory>();
                }
            }
            return lst;
        }

        public async Task<IEnumerable<spSelectCategory>> ListCategoryByIdAsync(Guid uniId)
        {
            List<spSelectCategory> lst;
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "spSelectCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryId", uniId));

                using (var drObj = await cmdObj.ExecuteReaderAsync())
                {
                    lst = drObj.MapToList<spSelectCategory>();
                }
            }
            return lst;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task UpdateCategoryAsync(Guid uniId, string CategoryName, string Description, string PhotoImage, Guid? UserId)
        {
            _context.Database.OpenConnection();
            using (DbCommand cmdObj = _context.Database.GetDbConnection().CreateCommand())
            {
                cmdObj.CommandText = "spUpdateCategory";
                cmdObj.CommandType = CommandType.StoredProcedure;
                cmdObj.Parameters.Add(new SqlParameter("@CategoryId", uniId));
                cmdObj.Parameters.Add(new SqlParameter("@CategoryName", CategoryName));
                cmdObj.Parameters.Add(new SqlParameter("@Description", Description));
                cmdObj.Parameters.Add(new SqlParameter("@PhotoImage", PhotoImage));
                cmdObj.Parameters.Add(new SqlParameter("@UserId", UserId));

                await cmdObj.ExecuteScalarAsync();
            }
        }
    }
}
