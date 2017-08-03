using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpactMan.Context.Db
{
    class ImpactManContext:DbContext
    {
        public ImpactManContext():base("GameContext")
        {
            Database.SetInitializer<ImpactManContext>(new CreateDatabaseIfNotExists <ImpactManContext>());
        }
        DbSet<User> users { get; set; }
    }
}
