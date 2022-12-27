using System;
using System.Text;
using linq_discoveries.Data;
using linq_discoveries.Models;
using static System.Formats.Asn1.AsnWriter;

/*
 * Deferred query execution is one of many extremely valuable strategies in the .NET tool set. 
 * I like to use it for conditionally building queries. However, when you use the wrong tool for the wrong job,
 * there can be unexpected and or undesirable side effects.
 */
namespace linq_discoveries.UseCases
{
	public class QueryExecution
    {
        /// <summary>
        /// This function is designed to showcase deferred query execution and demonstrate how this can lead to undesirable side effects.
        /// 
        /// 1. We are not taking advantage of any functionality provided by the IEnumerable type.
        /// 2. Additional queries performed on the people collection will cause unnecessary query execution/s. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> DeferredExecutionCollection()
		{
			var people = PeopleData.ThreePeople
                .Where(p => {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"Deferred execution collection. PersonId: {p.Id}");

					return !string.IsNullOrEmpty(p.FirstName);
				});

            //  Additional query/s to simulate how unexecuted queries.
            var addresses = people
                .Where(p => p.Addresses?.Count > 0)
                .ToList();

			return people;
		}

        /// <summary>
        /// This function is designed to showcase deferred query execution and demonstrate how this can lead to undesirable side effects.
        /// 
        /// 1. We are not taking advantage of any functionality provided by the IQueryable type.
        /// 2. Additional queries performed on the people collection will cause unnecessary query execution/s. 
        /// </summary>
        /// <returns></returns>
        public IQueryable<Person> DeferredExecutionQuery()
        {
            var query = PeopleData.ThreePeople
                .Where(p => {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"Deferred execution query. PersonId: {p.Id}");

                    return !string.IsNullOrEmpty(p.FirstName);
                })
                .AsQueryable();

            //  Additional query/s to simulate how unexecuted queries.
            var addresses = query
                .ToList()
                .Where(p => p?.Addresses?.Count > 0)
                .ToList();

            return query;
        }

        /// <summary>
        /// This function is designed to showcase an executed version of the above query.
        /// 
        /// The people query has been executed and will not be re-run in the following query for addresses or any subsequent queries.
        /// </summary>
        /// <returns></returns>
        public List<Person> ExecutedGetPeople()
        {
            var people = PeopleData.ThreePeople
                .Where(p => {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"Executed query. First name: {p.FirstName}");

                    return !string.IsNullOrEmpty(p.FirstName);
                })
                .ToList();

            var addresses = people
                .Where(p => p.Addresses?.Count > 0)
                .ToList();

            return people;
        }

        /// <summary>
        /// This query is designed to showcase deferred query execution and how to coditionally add to initial predicate/s.
        ///
        /// Whilst this example facilitates multiple executions, there is a designed strategy and purpose that takes advantage
        /// of deffered query execution.
        /// </summary>
        /// <param name="mustHaveAddress"></param>
        /// <returns></returns>
        public (int quantity, List<Person>) PlannedDeferredQueryExecution(bool mustHaveAddress = false)
        {
            //  Build default query.
            var query = PeopleData.ThreePeople
                .Where(p =>
                {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"Planned deferred query execution. Addresses: {p?.Addresses?.Count}");

                    return p.FirstName != default;
                })
                .AsQueryable();

            /* Get a count of all stored people, includes above predicate. 
             *  
             * This statement executes the above stored query however the query can still be  
             * re-executed or additional predicates added.
             */
            var totalPeopleCount = query
                .Count();

            //  Conditionally build apon existing predicate.
            if (mustHaveAddress)
            {
                query
                    .Where(p => p.Addresses != default
                        && p.Addresses.Count > 0);
            }

            /* Finalized the query by implementing a singleton query with a ToList.
             * 
             * As the scope of the 'query' variable is only for the life of this function, 
             * the query will no longer continue to be available for execution.
             */
            var peopleWithMultipleAddresses = query
                .OrderBy(p => p.FirstName)
                .ToList();

            return (totalPeopleCount, peopleWithMultipleAddresses);
        }
    }
}

