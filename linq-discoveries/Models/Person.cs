using System;
namespace linq_discoveries.Models
{
	public class Person : EntityBase
	{
		public string FirstName { get; set; } = default!;

		public List<Address> Addresses { get; set; } = new();
	}
}

