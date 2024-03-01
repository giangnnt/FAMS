using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net03_group02.src.Application.Shared.Constant
{
    public static class JwtConst
    {
        public const int ACCESS_TOKEN_EXP = 15 * 60; //15m
        public const int REFRESH_TOKEN_EXP = 3600 * 24 * 30; // 30 days
    }
}