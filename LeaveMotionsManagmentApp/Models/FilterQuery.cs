using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class FilterQuery
    {
        public string? Name{ get; set; }
        public string? State { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestedStartingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestedDueDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime Send { get; set; }

        public int? DisplayResults { get; set; }

    }
}
