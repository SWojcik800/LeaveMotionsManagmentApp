using LeaveMotionsManagmentApp.Interfaces;
using LeaveMotionsManagmentApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Services
{
    public class FilterQueryBuilder : IFilterQueryBuilder
    {
        public IQueryable<Motion> buildQuery(IQueryable<Motion> baseQuery, FilterQuery query)
        {
            if (query.Name != null)
                baseQuery = baseQuery
                     .Where(m => m.Name.Contains(query.Name)
                 || m.Employee.UserName.Contains(query.Name)
                );

            if (query.State != null)
                baseQuery = baseQuery
                    .Where(m => m.MotionState == ParseToEnum(query.State));

            //DateTime MinValue is the value of unassigned DateTime

            if (query.Send != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.Send.Date >= query.Send);

            if (query.RequestedStartingDate != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.RequestedStartingDate.Date >= query.RequestedStartingDate);

            if (query.RequestedDueDate != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.RequestedDueDate.Date <= query.RequestedDueDate);

            //Basic pagination
            if (query.DisplayResults != null)
            {
                if (query.Page == null)
                    query.Page = 1;

                query.PageCount = baseQuery.Count() % query.DisplayResults == 0 ?
                    baseQuery.Count() / query.DisplayResults
                    :
                    baseQuery.Count() / query.DisplayResults + 1;
                baseQuery = baseQuery.Skip((int)((query.Page - 1) * query.DisplayResults));

                baseQuery = baseQuery.Take((int)query.DisplayResults);
            }


            return baseQuery;


        }

        //Parsing to enum to complete LINQ query above
        private MotionState ParseToEnum(string state)
        {
            var capitalizedState = char.ToUpper(state[0]) + state.Substring(1);
            return Enum.Parse<MotionState>(capitalizedState);
        }
    }
}
