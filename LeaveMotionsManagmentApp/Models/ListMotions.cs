using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class ListMotions
    {
        public List<Motion> Motions { get; set; }
        public FilterQuery Query { get; set; }
    }
}
