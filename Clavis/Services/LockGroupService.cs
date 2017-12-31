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

        public List<LockGroupInfo> GetAll()
        {
            using (var db = new ClavisModelContainer())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.LockGroups.Select(lg => new LockGroupInfo { LockGroupId = lg.LockGroupId, LockOwners = lg.LockOwners, Locks = lg.Locks }).ToList();
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

        public void Delete(LockGroup lockGroup)
        {
            using(var db = new ClavisModelContainer())
            {
                GetById(lockGroup.LockGroupId).Locks.Clear();
                GetById(lockGroup.LockGroupId).LockUsers.Clear();
                db.LockGroups.Remove(lockGroup);
                db.SaveChanges();
            }
        }   
    }
    public class LockGroupInfo
    {
        public Guid LockGroupId { get; set; }
        public ICollection<LockOwner> LockOwners { get; set; }
        public ICollection<Lock> Locks { get; set; }
    }
}