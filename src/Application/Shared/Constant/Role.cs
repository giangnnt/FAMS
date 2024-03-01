using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Application.Shared.Constant
{
    public class RoleConst
    {
        public const string ADMIN = "ADMIN";
        public const int ADMIN_ID = 1;
        public const string MEMBER = "MEMBER";
        public const int MEMBER_ID = 6;
        public Dictionary<string, int> RoleId = new()
        {
            { ADMIN, ADMIN_ID },
            { MEMBER, MEMBER_ID},
        };
        public static int GetRoleId(string roleName)
        {
            return new RoleConst().RoleId[roleName];
        }
    }

}