using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net03_group02.src.Application.Shared.Enum;

namespace net03_group02.src.Application.Core
{
    public class Payload
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public Guid SessionId { get; set; }
        public UserStatusEnum Status { get; set; }
    }
}