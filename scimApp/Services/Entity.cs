using scimApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scimApp.Services
{
    public class Entity
    {
        ApplicationContext db;

        public Entity(ApplicationContext _db)
        {
            db = _db;
        }

       

        #region Group
        public string AddGroup(Group group)
        {
            string returnString = "";
            try
            {
                db.Groups.Add(group);
                db.SaveChanges();
                returnString = group.GroupID.ToString();
            }
            catch (Exception ex)
            {
                returnString = ex.Message;
            }
            
            return returnString;
        }
        public IEnumerable<Group> GetGroups() {
            try
            {         
                IEnumerable<Group> groups= from g in db.Groups
                                           select g;
                return groups;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Group> GetGroupsById(int ID) {
            try
            {
                IEnumerable<Group> groups = from g in db.Groups
                                            where g.GroupID == ID
                                            select g;
                return groups;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public bool UpdateGroup(Group group)
        {            
            try
            {
                Group GroupData = db.Groups.Single(groups => groups.GroupID == group.GroupID);
                GroupData.GroupGUID = group.GroupGUID;
                GroupData.FriendlyName = group.FriendlyName;
                GroupData.Name = group.Name;
                GroupData.Notes = group.Notes;
                GroupData.Description = group.Description;
                GroupData.LogonName = group.LogonName;
                GroupData.Email = group.Email;                
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;                               
            }
            
        }
        public bool DeleteGroup(int ID) {
            try
            {
                Group group = db.Groups.Single(groups => groups.GroupID == ID);                
                db.Groups.Remove(group);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;              
            }                    
        }
        #endregion

        #region Account
        public string AddAccount(Account account)
        {
            string returnString = "";
            try
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                returnString = account.AccountID.ToString();
            }
            catch (Exception ex)
            {
                returnString = ex.Message;
            }

            return returnString;
        }
        public IEnumerable<Account> GetAccount()
        {
            try
            {
                IEnumerable<Account> accounts = from a in db.Accounts
                                                select a;
                return accounts;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<Account> GetAccountById(int ID)
        {
            try
            {
                IEnumerable<Account> accounts = from g in db.Accounts
                                                where g.AccountID == ID
                                                select g;
                return accounts;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public bool UpdateAccount(Account account)
        {
            try
            {
                    Account AccountData = db.Accounts.Single(acc => acc.AccountID == account.AccountID);
                    AccountData.AccountGUID = account.AccountGUID;
                    AccountData.CannotChangePassword = account.CannotChangePassword;
                    AccountData.City = account.City;
                    AccountData.CityOfBirth = account.CityOfBirth;
                    AccountData.Company = account.Company;
                    AccountData.Country = account.Company;
                    AccountData.CountryOfBirth = account.CountryOfBirth;
                    AccountData.DateOfBirth = account.DateOfBirth;
                    AccountData.Department = account.Department;
                    AccountData.Description = account.Description;
                    AccountData.Disabled = account.Disabled;
                    AccountData.Email = account.Email;
                    AccountData.EmployeeID = account.EmployeeID;
                    AccountData.ExpiresOn = account.ExpiresOn;
                    AccountData.FirstName = account.FirstName;
                    AccountData.FriendlyName = account.FriendlyName;
                    AccountData.LastName = account.LastName;
                    AccountData.LockedOut = account.LockedOut;
                    AccountData.LogonName = account.LogonName;
                    AccountData.MiddleName = account.MiddleName;
                    AccountData.MobileNumber = account.MobileNumber;
                    AccountData.MustChangePasswordAtNextLogon = account.MustChangePasswordAtNextLogon;
                    AccountData.Name = account.Name;
                    AccountData.PasswordExpires = account.PasswordExpires;
                    AccountData.PasswordNeverExpires = account.PasswordNeverExpires;
                    AccountData.PersonID = account.PersonID;
                    AccountData.PersonalTitle = account.PersonalTitle;
                    AccountData.PreferredLanguage = account.PreferredLanguage;
                    AccountData.State = account.State;
                    AccountData.StreetAddress = account.StreetAddress;
                    AccountData.StreetAddress2 = account.StreetAddress2;
                    AccountData.Telephone = account.Telephone;
                    AccountData.ValidFrom = account.ValidFrom;
                    AccountData.ValidUntil = account.ValidUntil;
                    AccountData.ZipCode = account.ZipCode;
                    db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteAccount(int ID)
        {
            try
            {
                Account account = db.Accounts.Single(acc => acc.AccountID == ID);
                db.Accounts.Remove(account);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region GroupAccount
        public string AddGroupAccount(GroupAccount groupAccount)
        {
            string returnString = "";
            try
            {
                db.GroupAccounts.Add(groupAccount);
                db.SaveChanges();
                returnString = groupAccount.ID.ToString();
            }
            catch (Exception ex)
            {
                returnString = ex.Message;
            }

            return returnString;
        }
        public IEnumerable<GroupAccount> GetGroupAccount()
        {
            try
            {
                IEnumerable<GroupAccount> groupAccounts = from ga in db.GroupAccounts
                                                select ga;
                return groupAccounts;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IEnumerable<GroupAccount> GetGroupAccountById(int ID)
        {
            try
            {
                IEnumerable<GroupAccount> groupAccounts = from g in db.GroupAccounts
                                                where g.ID == ID
                                                select g;
                return groupAccounts;
            }

            catch (Exception)
            {
                return null;
            }
        }
        public bool UpdateGroupAccount(GroupAccount groupAccount)
        {
            try
            {
                GroupAccount groupAccountData = db.GroupAccounts.Single(gacc => gacc.ID == groupAccount.ID);
                groupAccountData.AccountID = groupAccount.AccountID;
                groupAccountData.GroupID = groupAccount.GroupID;              
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteGroupAccount(int ID)
        {
            try
            {
                GroupAccount groupaccount = db.GroupAccounts.Single(gacc => gacc.ID == ID);
                db.GroupAccounts.Remove(groupaccount);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
