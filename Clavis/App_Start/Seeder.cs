using System;
using Clavis.Services;

namespace Clavis
{
    public class Seeder
    {
        public void seed_db()
        {
            var locki = new Lock {IsOpen = false, LockId = new Guid()};
            var lockGroup = new LockGroup{Name = "MyFirstLockGroup", LockGroupId = new Guid()};
            var lockOwner = new LockOwner{LockOwnerId = new Guid()};

            lockOwner.LockGroups.Add(lockGroup);
            lockGroup.LockOwners.Add(lockOwner);
            lockGroup.Locks.Add(locki);
            locki.LockGroups.Add(lockGroup);

            new LockGroupService().AddOrUpdate(lockGroup);
            new LockOwnerService().AddOrUpdate(lockOwner);
        }
    }
}