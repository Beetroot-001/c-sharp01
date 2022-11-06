using System;

namespace ConsoleApp1
{
	public enum Gender
	{
		Male,
		Female
	}

	public class Friend
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class Person
	{
		public string Id { get; set; }
		public int Index { get; set; }
		public Guid Guid { get; set; }
		public bool IsActive { get; set; }
		public string Balance { get; set; }
		public int Age { get; set; }
		public string EyeColor { get; set; }
		public string Name { get; set; }
		public Gender Gender { get; set; }
		public string Company { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string About { get; set; }
		public DateTime Registered { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string[] Tags { get; set; }
		public Friend[] Friends { get; set; }
	}
}
