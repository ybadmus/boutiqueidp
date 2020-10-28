using API.Models;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IUserRepo
    {
        Task<bool> CheckIfNameExistsAsync(string strName);
        void SendEmailWithoutAttachment(string sMTPLicense, string sMTPFrom, string strEmpMail, string strSubject,
            string strszMessage, string sMTPFServer, int sMTPort, string sMTPUser, string sMTPwd, int prot);
        Task<IEnumerable<AspNetUsers>> ListAllUsersAsync();
        AspNetUsers GetSingleUserAync(string uniUserId);
        //Task<AspNetUsers> Create(CreateExpenseModel model);
        Task<AspNetUsers> UpdateUserAsync(string uniUserId, UpdateUserModel model);
        Task DeleteUsersAsync(string uniUserId);

        //Task psADAddPersonnelAsync(string szUserName, string szFirstName, string szLastName, string szEmailAddress,
        //    string szImage, Nullable<long> iEmployeeID, string szType, Nullable<long> iUserID, Nullable<System.DateTime> dStampDate,
        //    Nullable<long> iCompanyID, Nullable<int> iConcurrency, Guid? uniAssemblyId);
        //Task<string> GetDefaultPwdAsync();
        //Task<IEnumerable<psAssembly>> GetAssemblyByAssemblyIdAsync(Guid? uniAssemblyId);
        //Task UpdateAspNetUserCodeByUserIdAsync(string strId, string strAssemblyCode);
        //Task<IEnumerable<spADGetUserCredentials>> GetCredentialsDetails(string szUserName, long appId);
        //Task<IEnumerable<AspNetUsers>> GetSavedUserIdAsync(string strEmail);
        //Task<IEnumerable<spAdAddUser>> AddUserAsync(long pkId, long iGroupId,
        //    long iPersonelId, string szPassword, string szHashKey, Nullable<System.DateTime> dCreateDate,
        //    Nullable<System.DateTime> dStampDate, Nullable<long> iUserId, Nullable<int> iStatus, Nullable<int> iConcurrency);
        //Task<IEnumerable<spAdAddUserApp>> AddUserAppAsync(Nullable<long> pkId, Nullable<Guid> iUserId,
        //    Nullable<long> iAppId, Nullable<long> iMenuId, Nullable<long> iParent, Nullable<bool> bCheckStatus);

        //Task AddUserSegmentAsync(Nullable<long> pkId, Nullable<Guid> iUserId, Nullable<long> iSegmentId, Nullable<long> iSegmentItem);
        //Task AddUserLogAsync(long iUserId);
    }
}
