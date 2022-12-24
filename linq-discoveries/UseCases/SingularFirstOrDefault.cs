using System;
using linq_discoveries.Models;
using linq_discoveries.Data;

namespace linq_discoveries.UseCases
{
    /*
     * The below queries are simple demonstrations of how to effectively and efficiently use LINQ.
     * The output or reasons behind the query/s are not important.
     */
    public class SingularFirstOrDefault
	{
		public SingularFirstOrDefault() { }

		public Person? OptimisedGetPersonWithMoreThenOneAddress()
		{
			var person = PeopleData.People
				.FirstOrDefault(p => p.Addresses.Count > 1);

			return person;
		}

        /// <summary>
        /// By using the .Where() you are: 
        /// 1. iterating over the entire collection
        /// 2. passing those results to.FirstOrDefault()
        /// 3. Returning the 1st result
        /// 
        /// Why not just use.FirstOrDefault() and avoid the double handling
        /// </summary>
        /// <returns></returns>
        public Person? GetPersonWithMoreThenOneAddress()
        {
            var person = PeopleData.People
				.Where(p => p.Addresses.Count() > 1)
                .FirstOrDefault();

            return person;
        }
    }
}

