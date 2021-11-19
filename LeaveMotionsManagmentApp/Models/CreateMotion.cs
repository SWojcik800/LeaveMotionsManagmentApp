using LeaveMotionsManagmentApp.Models;
using LeaveMotionsManagmentApp.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class CreateMotion
    {
        
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        
        [MaxLength(150)]
        [Required]
        public string Description { get; set; }


        [LaterThanTomorrow]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RequestedStartingDate { get; set; }

        [LaterThanTomorrow]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RequestedDueDate { get; set; }

        public MotionState MotionState { get; set; }

    }
}
