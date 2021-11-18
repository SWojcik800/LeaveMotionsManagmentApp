using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Send { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestedStartingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RequestedDueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ExaminationDate { get; set; }

        public MotionState MotionState { get; set; }

        public string EmployeeId { get; set; }
        public virtual ApplicationUser Employee { get; set; }

        public string? SupervisorId { get; set; }
        public virtual ApplicationUser? Supervisor { get; set; }
    }
}
