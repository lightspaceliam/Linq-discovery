using System;
using linq_discoveries.Models;
namespace linq_discoveries.Data
{
	public static class PeopleData
	{
		public static List<Person> People = new List<Person>
		{
			new Person
			{
				Id = 1,
				FirstName = "John",
				Addresses = new List<Address>
				{
					new Address
					{
						Id = 1,
						Line = "John's 1st address",
						State = "Hobart"
					},
					new Address
					{
						Id = 2,
						Line = "John's 2nd address",
						State = "Victoria"
					},
				}
			},
            new Person
            {
                Id = 2,
                FirstName = "Tony",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id = 3,
                        Line = "Tony's only address",
                        State = "Queensland"
                    },
                }
            }
        };
	}
}

