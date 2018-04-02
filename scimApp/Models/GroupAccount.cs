﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace scimApp.Models
{
    public class GroupAccount
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int AccountID { get; set; }

        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }       
    }
}
