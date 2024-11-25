namespace API.Entities;

public class AppUser
{
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required byte[] passwordsHash { get; set; }
        public required byte[] passwordsSalt { get; set; }
}
