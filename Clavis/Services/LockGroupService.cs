using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Clavis.Services
{
    public class LockGroupService
    {
        public LockGroup GetById(Guid id)
        {
            using (var db = new ClavisModelContainer())
            {
                return db.LockGroups.Single(lg => lg.LockGroupId == id);
            }
        }

        public void Add(LockGroup lockGroup)
        {
            using (var db = new ClavisModelContainer())
            {
                if (!db.LockGroups.Any(lo => lo.LockGroupId == lockGroup.LockGroupId)) db.LockGroups.Add(lockGroup);
                db.SaveChanges();
            }
        }

        public void AddOrUpdate(LockGroup lockGroup)
        {
            using (var db = new ClavisModelContainer())
            {
                db.LockGroups.AddOrUpdate(lockGroup);
                db.SaveChanges();
            }
        }
    }
}