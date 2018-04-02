using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupApp.DomainModel
{
    public class Group
    {
        public int GroupID { get; set; }
        public Guid GroupGUID { get; set; }
        public string FriendlyName { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public string LogonName { get; set; }
        public string Email { get; set; }
    }
}
