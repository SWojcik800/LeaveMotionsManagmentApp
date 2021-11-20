using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeaveMotionsManagmentApp.Validation.Attributes;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public enum MotionState {
        Accepted,
        Denied,
        Pending,
        Cancelled
    }
    public class Motion
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name{ get; set; }
        [MaxLength(150)]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Send { get; set; }

        [LaterThanTomorrow]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RequestedStartingDate { get; set; }

        [LaterThanTomorrow]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime RequestedDueDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExaminationDate { get; set; }

        public MotionState MotionState { get; set; }

        public string EmployeeId { get; set; }
        public virtual ApplicationUser Employee { get; set; }

        public string SupervisorId { get; set; }
        public virtual ApplicationUser Supervisor { get; set; }
    }
}
