using System.ComponentModel.DataAnnotations;

namespace LynxPro.Models
{
    public class AlarmType
    {
        public int AlarmTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name", Description = "Alarm Type Name")]
        public string Name { get; set; }

        [Display(Name = "Code", Description = "Alarm Type Code")]
        public int Code { get; set; }
    }
}