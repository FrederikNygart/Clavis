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
            using (var db = new ClavisModelContainer())
            {
                return db.Locks.Single(l => l.LockId == id);
            }
        }

        internal List<LockInfo> GetAll()
        {
            using (var db = new ClavisModelContainer())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Locks.Select(l => new LockInfo { LockId = l.LockId, LockGroups = l.LockGroups }).ToList();
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

        public void ClearAll(ClavisModelContainer db)
        {
            db.Locks.RemoveRange(db.Locks);
        }
    }

    public class LockInfo
    {
        public Guid LockId { get; set; }
        public ICollection<LockGroup> LockGroups { get; set; }
    }
}