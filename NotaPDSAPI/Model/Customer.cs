using System;
namespace NotaPDS.Model
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public string ContactPersonFullName { get; set; }
		public string ContactPersonTel { get; set; }
		public string Adresse { get; set; }
		public string ImportantInformation { get; set; }
	}
}