using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clavis.Services
{
    public class LockUserService
    {
        public void Add(LockUser lockUser)
        {
            using (var db = new ClavisModelContainer())
            {
                db.LockUsers.Add(lockUser);
                db.SaveChanges();
            }
        }

        public LockUser GetById(Guid id)
        {
            using (var db = new ClavisModelContainer())
            {
                return db.LockUsers.Single(lu => lu.LockUserId == id);
            }
        }
    }
}