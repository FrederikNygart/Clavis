using Clavis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Clavis.Controllers
{
    public class LockGroupsController : ApiController
    {
        public LockGroupService lockGroups = new LockGroupService();

        public IEnumerable<LockGroupInfo> GetLockGroups() => lockGroups.GetAll();
    }
}
