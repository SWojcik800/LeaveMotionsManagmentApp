using System;
using System.ComponentModel.DataAnnotations;

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

        public int? Page { get; set; }
        public int? PageCount { get; set; }

    }
}
