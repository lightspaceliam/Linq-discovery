using System;
using linq_discoveries.Models;
using linq_discoveries.Data;
using System.Globalization;

namespace linq_discoveries.UseCases
{
    /*
     * The below queries are simple demonstrations of how to effectively and efficiently use LINQ.
     * The output or reasons behind the query/s are not important.
     */
    public class SingularFirstOrDefault
	{
        private List<Person> _people = new List<Person>();

		public SingularFirstOrDefault() { }

        public void Mock(int recordQuantity = 1000)
        {
            foreach(var i in Enumerable.Range(0, recordQuantity))
            {
                _people.Add(new Person
                {
                    Id = i,
                    FirstName = $"Firstname-{i}",
                    DateOfBirth = DateTime.Parse("1975-01-01"),
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Id = i,
                            Line = $"{i} Collins Street Melbouren",
                            State = "Victoria"
                        }
                    }
                });
            }
        }

        /// <summary>
        /// By using the .Where() you are: 
        /// 1. Iterating over the entire collection where the predicate is true 
        /// 2. Pass results to .FirstOrDefault() to simply get the 1st record from the collection
        /// 3. Returning the 1st result
        /// 
        /// Why not just use.FirstOrDefault() and avoid the double handling
        /// </summary>
        /// <returns></returns>
        public Person? GetPersonWithOneOrManyAddresses()
        {
            Console.WriteLine($"1 People count: {_people.Count.ToString("N", new CultureInfo("en-AU"))}");
            var person = _people
                .Where(p => {
                    Console.WriteLine($"where: {p.Id}");
                    return p?.Addresses?.Count > 0;
                })
                .FirstOrDefault();

            return person;
        }

        public Person? OptimisedGetPersonWithOneOrManyAddresses()
		{
            Console.WriteLine($"2 People count: {_people.Count.ToString("N", new CultureInfo("en-AU"))}");
            var person = _people
                //.FirstOrDefault(p => p?.Addresses?.Count > 0);
                .FirstOrDefault();

            return person;
		}
    }
}

