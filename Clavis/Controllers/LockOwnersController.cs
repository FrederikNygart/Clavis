using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Clavis.Services;

namespace Clavis.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LockOwnersController : ApiController
    {
        private readonly LockOwnerService _lockOwners = new LockOwnerService();

        /// <summary>
        /// Get all lockowners
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LockOwnerInfo> GetAll() => _lockOwners.GetAll();
    
        /// <summary>
        /// Get lockowner by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LockOwnerInfo GetLockOwner(Guid id) => _lockOwners.GetById(id);
        
    }
}
