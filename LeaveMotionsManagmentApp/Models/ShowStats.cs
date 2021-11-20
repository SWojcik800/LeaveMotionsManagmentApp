using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Models
{
    public class ShowStats
    {
        
        public ShowStats(List<Motion> motions)
        {
            All = motions.Count();
            Pending = motions.Where(m => m.MotionState == MotionState.Pending).Count();
            Accepted = motions.Where(m => m.MotionState == MotionState.Accepted).Count();
            Denied = motions.Where(m => m.MotionState == MotionState.Denied).Count();
            Cancelled = motions.Where(m => m.MotionState == MotionState.Cancelled).Count();
        }



        public int All { get; set; } = 0;
        public int Pending { get; set; } = 0;
        public int Accepted { get; set; } = 0;
        public int Denied { get; set; } = 0;
        public int Cancelled { get; set; } = 0;
    }
}
