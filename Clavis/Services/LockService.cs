using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clavis.Services
{
    public class LockService
    {
        public Lock GetById(Guid id)
        {
            using (var db =  new ClavisModelContainer())
            {
                return db.Locks.Single(l => l.LockId == id);
            }
        }

        public void Add(Lock @lock)
        {
            using (var db = new ClavisModelContainer())
            {
                db.Locks.Add(@lock);
                db.SaveChanges();
            }
        }
    }
}