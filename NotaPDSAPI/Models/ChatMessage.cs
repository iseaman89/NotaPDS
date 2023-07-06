using System.ComponentModel.DataAnnotations;

namespace NotaPDSAPI.Model
{
	public class ChatMessage
	{
		[Key]
		public int Id { get; set; }
		public DateTime? Date { get; set; }
		public string? Text { get; set; }
		public User? Sender { get; set; }
	}
}