using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DAL.Entity
{
    [Table("Task")]
    public class Task
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
        public int PerfomerId { get; set; }

        [Display(Name = "Рекомендован")]
        public virtual User Recomended { get; set; }
    }
}