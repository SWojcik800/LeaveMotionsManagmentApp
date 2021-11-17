using LeaveMotionsManagmentApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class CreateMotion
    {
        public string Name { get; set; }
        public string Description { get; set; }


        [DataType(DataType.Date)]
        public DateTime RequestedStartingDate { get; set; }        
        [DataType(DataType.Date)]
        public DateTime RequestedDueDate { get; set; }

        public MotionState MotionState { get; set; }

    }
}
