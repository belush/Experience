using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entity
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Готов ли трудиться?")]
        public bool isReady { get; set; }
        //public string Type { get; set; }
    }
}