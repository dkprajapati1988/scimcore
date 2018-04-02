using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace scimApp.Models
{
    public class Account
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public Guid AccountGUID {get;set;}
        public int PersonID {get;set;}
        public string FriendlyName {get;set;}
        public string Name {get;set;}
        public string LogonName {get;set;}
        public string Email {get;set;}
        public string Description {get;set;}
        public bool Disabled {get;set;}
        public bool LockedOut {get;set;}
        public DateTime ExpiresOn {get;set;}
        public DateTime ValidFrom {get;set;}
        public DateTime ValidUntil {get;set;}
        public bool PasswordNeverExpires {get;set;}
        public bool CannotChangePassword {get;set;}
        public bool PasswordExpires {get;set;} 
        public bool MustChangePasswordAtNextLogon {get;set;}
        public string PersonalTitle {get;set;}
        public string FirstName {get;set;}
        public string MiddleName {get;set;}
        public string LastName {get;set;}
        public string StreetAddress {get;set;}
        public string StreetAddress2 {get;set;}
        public string City {get;set;}
        public string State {get;set;}
        public string ZipCode {get;set;}
        public string Country {get;set;}
        public string Company {get;set;}
        public string Department {get;set;}
        public string PreferredLanguage {get;set;}
        public string Telephone {get;set;}
        public string MobileNumber {get;set;}
        public DateTime DateOfBirth {get;set;}
        public string CityOfBirth {get;set;}
        public string CountryOfBirth {get;set;}
        public int EmployeeID {get;set;}

        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
    }
}
