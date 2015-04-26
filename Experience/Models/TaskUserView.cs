using DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Experience.Models
{
    public class TaskUserView
    {
        [Key]
        public int TaskId { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата добавления")]
        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }
        [Display(Name = "Заказчик")]
        public virtual User Customer { get; set; }
        [Display(Name = "Исполнитель")]
        public string PerfomerName { get; set; }
    }
}