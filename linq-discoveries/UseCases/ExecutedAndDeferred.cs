using System;
using linq_discoveries.Data;
using linq_discoveries.Models;

namespace linq_discoveries.UseCases
{
	public class ExecutedAndDeferred
	{
		public IEnumerable<Person> GetPeopleDeferred()
		{
			var people = PeopleData.People
				.Select(p => {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"DEFERRED executing over people collection {p.Id}");

					return p;
				});

            var addresses = people
                .Where(p => p.Addresses.Count > 0)
                .ToList();
			return people;
		}

        public List<Person> GetPeopleExecuted()
        {
            var people = PeopleData.People
                .Select(p => {

                    // Write to the console to demonstrate how IEnumerable will execute 
                    Console.WriteLine($"EXECUTED executing over people collection {p.FirstName}");

                    return p;
                })
                .ToList();

            var addresses = people
                .Where(p => p.Addresses.Count > 0)
                .ToList();
            return people;
        }
    }
}

