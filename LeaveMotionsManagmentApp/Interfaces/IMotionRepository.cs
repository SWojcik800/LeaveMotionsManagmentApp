using LeaveMotionsManagmentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Interfaces
{
    public interface IMotionRepository
    {
        Task<List<Motion>> ListMotions();
        Task<Motion> GetMotion(int? id);
        Task<Motion> CancelMotion(int? id);
        Task<Motion> CreateMotion(CreateMotion model);
        Task UpdateMotion(int id, Motion editedMotion);
        Task DeleteMotion(int? id);
        Task AcceptMotion(int id);
        Task DenyMotion(int id);
        Task<List<Motion>> FilterMotions(FilterQuery query);
    }
}