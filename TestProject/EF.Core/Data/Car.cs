using System;
using System.ComponentModel.DataAnnotations;

namespace EF.Core.Data
{
    public class Car : BaseEntity
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Model is required")]

        public string Model { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Make is required")]
        public DateTime Make { get; set; }

    }
}
