using LeaveMotionsManagmentApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Interfaces
{
    public interface IFilterQueryBuilder
    {
        IQueryable<Motion> buildQuery(IQueryable<Motion> baseQuery, FilterQuery query);
    }
}