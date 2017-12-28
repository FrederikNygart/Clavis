using System;
using System.Collections.Generic;
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
                db.LockGroups.Add(lockGroup);
                db.SaveChanges();
            }
        }
    }
}