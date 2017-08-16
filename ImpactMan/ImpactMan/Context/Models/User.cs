namespace ImpactMan.Context.Models
{
    using ImpactMan.Interfaces.Models.User;

    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public int HighScore { get; set; }
        public int CurrentScore { get; set; }
    }
}
