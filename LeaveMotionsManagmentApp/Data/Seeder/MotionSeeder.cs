using LeaveMotionsManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Data.Seeder
{
    public static class MotionSeeder
    {
        public static List<Motion> GetMotions(string employeeId, string supervisorId)
        {
            var motions = new List<Motion>();


            //Pending
            for (int i = 0; i < 10; i++)
            {
                var motion = new Motion()
                {
                    //Id = i,
                    Name = $"Motion {i}",
                    Description = $"Motion {i}",
                    MotionState = MotionState.Pending,
                    EmployeeId = employeeId,
                    Send = (DateTime.Now),
                    RequestedStartingDate = (DateTime.Now.AddDays(4)),
                    RequestedDueDate = (DateTime.Now.AddDays(14))
                };
                motions.Add(motion);
            }
            //Accepted
            for (int i = 11; i < 20; i++)
            {
                var motion = new Motion()
                {
                    //Id = i,
                    Name = $"Motion {i}",
                    Description = $"Motion {i}",
                    MotionState = MotionState.Accepted,
                    EmployeeId = employeeId,
                    SupervisorId = supervisorId,
                    Send = (DateTime.Now.AddDays(-1)),
                    ExaminationDate = (DateTime.Now),
                    RequestedStartingDate = (DateTime.Now.AddDays(14)),
                    RequestedDueDate = (DateTime.Now.AddDays(24))

                };
                motions.Add(motion);
            }

            //Denied
            for (int i = 21; i < 30; i++)
            {
                var motion = new Motion()
                {
                    //Id = i,
                    Name = $"Motion {i}",
                    Description = $"Motion {i}",
                    MotionState = MotionState.Denied,
                    EmployeeId = employeeId,
                    SupervisorId = supervisorId,
                    Send = (DateTime.Now.AddDays(-2)),
                    ExaminationDate = (DateTime.Now),
                    RequestedStartingDate = (DateTime.Now.AddDays(14)),
                    RequestedDueDate = (DateTime.Now.AddDays(24))
                };
                motions.Add(motion);
            }

            //Cancelled
            for (int i = 31; i < 40; i++)
            {
                var motion = new Motion()
                {
                    //Id = i,
                    Name = $"Motion {i}",
                    Description = $"Motion {i}",
                    MotionState = MotionState.Cancelled,
                    EmployeeId = employeeId,
                    SupervisorId = employeeId,
                    Send = (DateTime.Now),
                    ExaminationDate = (DateTime.Now.AddDays(1)),
                    RequestedStartingDate = (DateTime.Now.AddDays(14)),
                    RequestedDueDate = (DateTime.Now.AddDays(24))
                };
                motions.Add(motion);
            }

            return motions;




        }
    }
}
