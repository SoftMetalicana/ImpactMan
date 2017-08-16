
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpactMan.Context.Db;

namespace ImpactMan.Core
{
    /// <summary>
    /// The DataLoader contains all the classes responsible for taking the data from the context
    /// </summary>
    class DataLoader
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
    }
}
