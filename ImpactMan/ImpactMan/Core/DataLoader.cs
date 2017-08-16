
using System;
using System.Collections.Generic;
namespace ImpactMan.Core
{
    using System.Linq;
    using ImpactMan.Context.Db;
    using ImpactMan.Interfaces.Core;

    /// <summary>
    /// The DataLoader contains all the classes responsible for taking the data from the context
    /// </summary>
    class DataLoader:IDataLoader
    {
        private ImpactManContext context;
        public DataLoader(ImpactManContext context)
        {
            this.context = context; 
        }
        public Dictionary<string, int> LoadHighScores()
        {
           
            Dictionary<string, int> topUsersDict = new Dictionary<string, int>();
            var topUsers = this.context.Users.ToList().OrderByDescending(u => u.HighScore).Take(10).ToList();
            if (topUsers.Count>0)
            {
                foreach (var user in topUsers)
                {
                    topUsersDict.Add(user.Name, user.HighScore);
                }
            }
            return topUsersDict;
            
        }

        public Dictionary<string, int> LoadLogInfo()
        {
            throw new NotImplementedException();
        }
    }
}
