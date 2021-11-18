using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class FilterQuery
    {
        public string? Name{ get; set; }
        public string? State { get; set; }

        public DateTime RequestedStartingDate { get; set; }
        public DateTime RequestedDueDate { get; set; }
        public DateTime Send { get; set; }

        public int? DisplayResults { get; set; }

    }
}
