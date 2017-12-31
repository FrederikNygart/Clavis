﻿using Clavis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Clavis.Controllers
{
    public class LocksController : ApiController
    {
        private LockService locks = new LockService();

        public IEnumerable<LockInfo> GetAll() => locks.GetAll();
    }
}
