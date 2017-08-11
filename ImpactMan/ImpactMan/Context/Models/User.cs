using System.ComponentModel.DataAnnotations;
using ImpactMan.Interfaces.Models.User;

namespace ImpactMan.Context.Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Level { get; set; }
        public int HightScore { get; set; }
        public int CurrentScore { get; set; }
    }
}
