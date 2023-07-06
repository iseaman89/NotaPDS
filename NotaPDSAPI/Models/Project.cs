using System.ComponentModel.DataAnnotations;

namespace NotaPDSAPI.Model
{
	public partial class Project
	{
        [Key]
        public int Id { get; set; }
        public string? ProjectManagerNumber { get; set; }
        public string? YearNumber { get; set; }
        public string? ProjectNumber { get; set; }
        public string? FullNumber { get; set; }
        public virtual Customer? Customer { get; set; }
        public ICollection<ChatMessage>? Chat { get; set; }
    }
}