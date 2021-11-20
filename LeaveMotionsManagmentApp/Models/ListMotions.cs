using System.Collections.Generic;

namespace LeaveMotionsManagmentApp.Models
{
    public class ListMotions
    {
        public List<Motion> Motions { get; set; }
        public FilterQuery Query { get; set; }
    }
}
