namespace ImpactMan.Interfaces.Models.User
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string Password { get; }
        int CurrentScore { get; }
        int Level { get; }
    }
}
