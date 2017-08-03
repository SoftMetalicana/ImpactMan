namespace ImpactMan.Context.Db
{
    using System.Data.Entity;
    
    public class ImpactManContext : DbContext
    {
        private DbSet<User> users;

        public ImpactManContext()
            : base("GameContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists <ImpactManContext>());
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
