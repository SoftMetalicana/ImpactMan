using ImpactMan.Interfaces.Models.User;

namespace ImpactMan.Context.Db
{
    using System.Data.Entity;
    using ImpactMan.Context.Models;

    /// <summary>
    /// 
    /// The Context is responsible for saving the user information in the database
    /// </summary>
    public class ImpactManContext : DbContext
    {
        private DbSet<User> users;

        public ImpactManContext()
            : base("GameContext")
        {
            ///Initialize  the database onlt if it does not exists
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ImpactManContext>());
        }

        public DbSet<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}
