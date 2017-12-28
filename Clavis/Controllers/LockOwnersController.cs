using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Clavis.Services;

namespace Clavis.Controllers
{
    public class LockOwnersController : ApiController
    {
        private LockOwnerService LockOwners = new LockOwnerService();

        /// <summary>
        /// Gets all lockowners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LockOwnerInfo> GetAll() => LockOwners.GetAll().Select(lo => new LockOwnerInfo{ LockGroups = lo.LockGroups, LockOwnerId = lo.LockOwnerId});
    
        /// <summary>
        /// Get lockowner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LockOwnerInfo GetLockOwner(Guid id) => LockOwners.GetById(id);
        
    }
}
