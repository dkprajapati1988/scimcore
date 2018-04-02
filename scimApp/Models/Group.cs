using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace scimApp.Models
{
    public class Group
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GroupID { get; set; }
        public Guid GroupGUID { get; set; }
        public string FriendlyName { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string LogonName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<GroupAccount> GroupAccounts { get; set; }
    }
}
