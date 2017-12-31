using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Clavis.Services
{
    public class LockOwnerService
    {
        public void Add(LockOwner lockOwner)
        {
            using (var db = new ClavisModelContainer())
            {
                if (!db.LockOwners.Any(lo => lo.LockOwnerId == lockOwner.LockOwnerId)) db.LockOwners.Add(lockOwner);

                db.SaveChanges();
            }
        }

        public void AddOrUpdate(LockOwner lockOwner)
        {
            using (var db = new ClavisModelContainer())
            {
                db.LockOwners.AddOrUpdate(lockOwner);
                db.SaveChanges();
            }
        }

        public LockOwnerInfo GetById(Guid id)
        {
            using (var db = new ClavisModelContainer())
            {
                var lockOwner = db.LockOwners.Single(lo => lo.LockOwnerId == id);
                return new LockOwnerInfo
                {
                    LockOwnerId = lockOwner.LockOwnerId,
                    LockGroups = lockOwner.LockGroups
                };
            }
        }

        public List<LockOwnerInfo> GetAll()
        {
            using (var db = new ClavisModelContainer())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.LockOwners
                    .Select(lo => new LockOwnerInfo
                    {
                        LockOwnerId = lo.LockOwnerId,
                        LockGroups = lo.LockGroups
                    })
                    .ToList();
            }
        }

        public void ClearAll(ClavisModelContainer db)
        {
            db.LockOwners.RemoveRange(db.LockOwners);
        }
    }

    public class LockOwnerInfo
    {
        public Guid LockOwnerId { get; set; }
        public ICollection<LockGroup> LockGroups { get; set; }
    }
}