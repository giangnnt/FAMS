using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Application.Shared.Handler
{
    public class BaseResp
    {
        public string Message { get; set; } = null!;
        public bool Success { get; set; }
    }
}