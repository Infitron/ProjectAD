﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Controllers.V2.Contract.Request
{
    public class UpdateLoginStatusRequest
    {
        public int UserId { get; set; }
        public int StatusId { get; set; }
    }
}
