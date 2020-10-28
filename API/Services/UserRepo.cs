using API.Models;
using Database.Data;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserRepo : IUserRepo
    {
        private BoutiqueContext _context;

        public UserRepo(BoutiqueContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CheckIfNameExistsAsync(string strName)
        {
            return await _context.AspNetUsers.AnyAsync(a => a.UserName == strName);
        }

        public Task DeleteUsersAsync(string uniUserId)
        {
            throw new NotImplementedException();
        }

        public AspNetUsers GetSingleUserAync(string uniUserId)
        {
            throw new NotImplementedException();
            //return await _context.AspNetUsers.Where(a => a.Id == uniUserId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AspNetUsers>> ListAllUsersAsync()
        {
            return await _context.AspNetUsers.ToListAsync();
        }

        public void SendEmailWithoutAttachment(string sMTPLicense, string sMTPFrom, string strEmpMail, string strSubject, string strszMessage, string sMTPFServer, int sMTPort, string sMTPUser, string sMTPwd, int prot)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUsers> UpdateUserAsync(string uniUserId, UpdateUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
