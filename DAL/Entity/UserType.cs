using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entity
{
    [Table("UserType")]
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
    }
}