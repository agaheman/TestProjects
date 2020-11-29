namespace SerilogWithOptionPattern.Model
{
    public class DeveloperInfo
    {
        public string Name { get; set; }
        public Detail Detail { get; set; }
    }

    public class Detail
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAlive { get; set; }
    }

}
