using LeaveMotionsManagmentApp.Interfaces;
using LeaveMotionsManagmentApp.Models;
using System;
using System.Linq;

namespace LeaveMotionsManagmentApp.Services
{
    public class FilterQueryBuilder : IFilterQueryBuilder
    {
        
        public IQueryable<Motion> buildQuery(IQueryable<Motion> baseQuery, FilterQuery query)
        {
            
            //Name and state filters
            AddBasicFilters(query, ref baseQuery);
            //DateTime MinValue is the value of unassigned DateTime
            AddDateFilters(query, ref baseQuery);
            //Basic pagination
            AddPagination(ref query, ref baseQuery);
            return baseQuery;
        }

        //Name and State filters
        private void AddBasicFilters(FilterQuery query, ref IQueryable<Motion> baseQuery)
        {
            if (query.Name != null)
                baseQuery = baseQuery
                     .Where(m => m.Name.Contains(query.Name)
                 || m.Employee.UserName.Contains(query.Name)
                );

            if (query.State != null)
                baseQuery = baseQuery
                    .Where(m => m.MotionState == ParseToEnum(query.State));
        }

        //Send, RequestStartingDate and RequestDueDate filters
        private void AddDateFilters(FilterQuery query, ref IQueryable<Motion> baseQuery)
        {

            if (query.Send != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.Send.Date >= query.Send);

            if (query.RequestedStartingDate != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.RequestedStartingDate.Date >= query.RequestedStartingDate);

            if (query.RequestedDueDate != DateTime.MinValue)
                baseQuery = baseQuery
                    .Where(m => m.RequestedDueDate.Date <= query.RequestedDueDate);
        }

        //Pagination mechanism
        private void AddPagination(ref FilterQuery query, ref IQueryable<Motion> baseQuery)
        {
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
        }

        //Parsing to enum to complete LINQ query above
        private MotionState ParseToEnum(string state)
        {
            var capitalizedState = char.ToUpper(state[0]) + state.Substring(1);
            return Enum.Parse<MotionState>(capitalizedState);
        }
    }
}
