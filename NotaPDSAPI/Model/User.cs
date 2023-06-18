namespace NotaPDS.Model
{
    public class User
	{
		public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int ProjectLeiterNumber { get; set; }
        public bool ProjectLeiter { get; set; }
    }
}

