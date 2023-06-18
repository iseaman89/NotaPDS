namespace NotaPDS.Model
{
	public partial class ProjectDB 
	{
        public int Id { get; set; }
        public string ProjectManagerNumber { get; set; }
        public string YearNumber { get; set; }
        public string ProjectNumber { get; set; }
        public string FullNumber { get; set; }
        public Customer CustomerData { get; set; }
    }
}