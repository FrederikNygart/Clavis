using System;
using System.Collections.Generic;
using Clavis.Services;

namespace Clavis
{
    public class Seeder
    {
        private List<Lock> Locks = new List<Lock>
        {
            new Lock {IsOpen = false, LockId = new Guid()},
        };

        private List<LockGroup> LockGroups = new List<LockGroup> {
            new LockGroup { Name = "Fraza", LockGroupId = new Guid()},
        };

        private List<LockOwner> LockOwners = new List<LockOwner>
        {
            new LockOwner{LockOwnerId = new Guid()},
        };

        public void seed_db()
        {
            foreach (var lck in Locks)
            {
                LockGroups[0].Locks.Add(lck);
            }

            foreach(var lockOwner in LockOwners)
            {
                LockGroups[0].LockOwners.Add(lockOwner);
            }

            LockGroups.ForEach(lg => new LockGroupService().AddOrUpdate(lg));
        }

        public void firstSeed()
        {

            var locki = new Lock { IsOpen = false, LockId = Guid.NewGuid() };
            var lockGroup = new LockGroup { Name = "MyFirstLockGroup", LockGroupId = Guid.NewGuid() };
            var lockOwner = new LockOwner { LockOwnerId = Guid.NewGuid() };

            lockOwner.LockGroups.Add(lockGroup);
            lockGroup.LockOwners.Add(lockOwner);
            lockGroup.Locks.Add(locki);
            locki.LockGroups.Add(lockGroup);

            new LockGroupService().AddOrUpdate(lockGroup);
            new LockOwnerService().AddOrUpdate(lockOwner);
        }
    }
}