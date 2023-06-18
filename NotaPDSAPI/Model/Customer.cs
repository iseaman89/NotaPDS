using System.ComponentModel.DataAnnotations;

namespace NotaPDSAPI.Model
{
	public class Customer
	{
		[Key]
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? ContactPersonFullName { get; set; }
		public string? ContactPersonTel { get; set; }
		public string? Adresse { get; set; }
        public string? ImportantInformation { get; set; }
	}
}