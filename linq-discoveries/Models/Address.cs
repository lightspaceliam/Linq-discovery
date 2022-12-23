using System;
namespace linq_discoveries.Models
{
	public class Address : EntityBase
	{
		public string Line { get; set; } = default!;
		public string State { get; set; } = default!;
    }
}

