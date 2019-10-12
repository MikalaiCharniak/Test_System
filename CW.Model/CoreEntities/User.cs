using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CW.Model.CoreEntities
{
    public class User : IdentityUser
    {
        public User()
        {
            Results = new HashSet<Result>();
        }

        public ICollection<Result> Results { get; private set; } 
    }
}
