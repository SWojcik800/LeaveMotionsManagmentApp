using LeaveMotionsManagmentApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Interfaces
{
    public interface IMotionRepository
    {
        Task<List<Motion>> ListMotions();
        Task<Motion> GetMotion(int? id);
    }
}