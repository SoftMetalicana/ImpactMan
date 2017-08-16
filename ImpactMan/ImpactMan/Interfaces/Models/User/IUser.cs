namespace ImpactMan.Interfaces.Models.User
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string Password { get; set; }
        int CurrentScore { get; }
        int HighScore { get; set; }
        int Level { get; }
    }
}
